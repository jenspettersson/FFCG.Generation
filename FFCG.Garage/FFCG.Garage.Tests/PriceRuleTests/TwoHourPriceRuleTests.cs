namespace FFCG.Garage.Tests.PriceRuleTests
{
    using System;
    using NUnit.Framework;
    using Pricing.PriceRules;

    [TestFixture]
    public class TwoHourPriceRuleTests
    {
        [Test]
        public void Should_return_correct_amount_for_two_hours_with_no_minutes()
        {
            var oneHourPriceRule = new TwoHourPriceRule();
            decimal amount = oneHourPriceRule.Amount(new TimeSpan(2, 0, 0));

            Assert.AreEqual(6m, amount);
        }

        [Test]
        public void Should_charge_for_only_minutes_if_two_hours_hasnt_passed()
        {
            var oneHourPriceRule = new TwoHourPriceRule();
            decimal amount = oneHourPriceRule.Amount(new TimeSpan(1, 30, 0));

            Assert.AreEqual(3m, amount);
        }

        [Test]
        public void Should_only_charge_for_second_hour()
        {
            var oneHourPriceRule = new TwoHourPriceRule();
            decimal amount = oneHourPriceRule.Amount(new TimeSpan(2, 30, 0));

            Assert.AreEqual(6m, amount);
        }
    }
}