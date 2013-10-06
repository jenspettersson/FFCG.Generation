namespace FFCG.Garage.Tests.PriceRuleTests
{
    using System;
    using Checkout;
    using NUnit.Framework;
    using Pricing.PriceRules;

    [TestFixture]
    public class ThreeOrMoreHoursPriceRuleTests
    {
        [Test]
        public void Should_return_correct_amount_for_three_hours_with_no_minutes()
        {
            var threeOrMoreHoursPriceRule = new ThreeOrMoreHoursPriceRule();
            decimal amount = threeOrMoreHoursPriceRule.Amount(new TimeSpan(3, 0, 0));

            Assert.AreEqual(4m, amount);
        }

        [Test]
        public void Should_return_correct_amount_for_only_minutes()
        {
            var threeOrMoreHoursPriceRule = new ThreeOrMoreHoursPriceRule();
            decimal amount = threeOrMoreHoursPriceRule.Amount(new TimeSpan(2, 30, 0));

            Assert.AreEqual(2m, amount);
        }

        [Test]
        public void Should_return_correct_amount_for_more_than_four_hours()
        {
            var threeOrMoreHoursPriceRule = new ThreeOrMoreHoursPriceRule();
            decimal amount = threeOrMoreHoursPriceRule.Amount(new TimeSpan(6, 0, 0));

            Assert.AreEqual(16m, amount);
        }

        [Test]
        public void Should_return_correct_amount_for_more_than_four_hours_including_minutes()
        {
            var threeOrMoreHoursPriceRule = new ThreeOrMoreHoursPriceRule();
            decimal amount = threeOrMoreHoursPriceRule.Amount(new TimeSpan(6, 30, 0));

            Assert.AreEqual(18m, amount);
        }
    }
}