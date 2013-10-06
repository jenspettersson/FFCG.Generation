namespace FFCG.Garage.Tests
{
    using System;
    using System.Collections.Generic;
    using Checkout;
    using NUnit.Framework;
    using Pricing;
    using Pricing.PriceRules;

    [TestFixture]
    public class When_checking_out_with_CheckoutService
    {
        private Invoice _invoice;

        [SetUp]
        public void SetUp()
        {
            var parkingDate = new DateTime(2013, 10, 06, 12, 0, 0);
            var parkingReceipt = ParkingReceipt.Create(parkingDate);

            DateTime checkoutTime = parkingDate.AddHours(5).AddMinutes(30);

            var priceCalculator = new PriceCalculator(new List<IParkingPriceRule>
                {
                    new OneHourPriceRule(),
                    new TwoHourPriceRule(),
                    new ThreeOrMoreHoursPriceRule()
                });

            var checkoutService = new CheckoutService(new TestableTimeService(checkoutTime), priceCalculator);
            _invoice = checkoutService.Checkout(parkingReceipt);
        }

        [Test]
        public void A_payment_invoice_should_be_created()
        {
            Assert.NotNull(_invoice);
        }

        [Test]
        public void The_payment_invoice_should_show_hours_parked()
        {
            Assert.AreEqual(5, _invoice.HoursParked); 
        }

        [Test]
        public void The_payment_invoice_should_show_minutes_parked()
        {
            Assert.AreEqual(30, _invoice.MinutesParked); 
        }

        [Test]
        public void The_payment_invoice_should_show_total_amount_to_pay()
        {
            Assert.AreEqual(30.0m, _invoice.TotalAmount);
        }
    }
}