namespace FFCG.Garage.Tests.PriceRuleTests
{
    using System;
    using NUnit.Framework;
    using Pricing.PriceRules;

    [TestFixture]
    public class OneHourPriceRuleTests
    {
        [Test]
        public void Should_return_correct_amount_for_one_hour_with_no_minutes()
        {
            var oneHourPriceRule = new OneHourPriceRule();
            decimal amount = oneHourPriceRule.Amount(new TimeSpan(1, 0, 0));

            Assert.AreEqual(10m, amount);
        }

        [Test]
        public void Should_return_correct_amount_for_only_minutes()
        {
            var oneHourPriceRule = new OneHourPriceRule();
            decimal amount = oneHourPriceRule.Amount(new TimeSpan(0, 30, 0));

            Assert.AreEqual(5m, amount);
        }

        [Test]
        public void Should_only_charge_for_first_hour()
        {
            var oneHourPriceRule = new OneHourPriceRule();
            decimal amount = oneHourPriceRule.Amount(new TimeSpan(1, 30, 0));

            Assert.AreEqual(10m, amount);
        }
    }
}