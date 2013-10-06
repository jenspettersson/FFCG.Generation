namespace FFCG.Garage.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Pricing;
    using Pricing.PriceRules;

    [TestFixture]
    public class When_calculating_price_to_pay_with_given_rules
    {
        private decimal _amount;

        [SetUp]
        public void SetUp()
        {
            

            var timeSpan = new TimeSpan(0, 5, 30, 0);

            var priceCalculator = new PriceCalculator(new List<IParkingPriceRule>
                {
                    new OneHourPriceRule(),
                    new TwoHourPriceRule(),
                    new ThreeOrMoreHoursPriceRule()
                });
            _amount = priceCalculator.Calculate(timeSpan);
        }

        [Test]
        public void An_amount_to_pay_should_be_calculated()
        {
            Assert.AreEqual(30.0m, _amount);
        }
    }
}