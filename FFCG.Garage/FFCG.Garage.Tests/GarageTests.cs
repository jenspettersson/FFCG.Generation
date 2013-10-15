namespace FFCG.Garage.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Checkout;
    using NUnit.Framework;
    using Pricing;
    using Pricing.PriceRules;

    [TestFixture]
    public class GarageTests
    {
        private Garage _garage;

        [SetUp]
        public void SetUp()
        {
            var priceCalculator = new PriceCalculator(new List<IParkingPriceRule>());
            _garage = new Garage(new CheckoutService(priceCalculator));
        }

        [Test]
        public void ParkCar_should_put_one_car_in_the_garage()
        {
            var car = new Car();
            _garage.ParkCar(car);

            Assert.AreEqual(1, _garage.ParkedCars.Count());
        }

        [Test]
        public void ParkCar_should_park_the_given_car_in_the_garage()
        {
            var car = new Car { LicenseNumber = "ABC123" };
            _garage.ParkCar(car);

            Car parkedCar = _garage.ParkedCars.First();
            Assert.AreSame(car, parkedCar);
        }

        [Test]
        public void ParkCar_should_give_a_parking_receipt()
        {
            var car = new Car { LicenseNumber = "ABC123" };
            ParkingReceipt receipt = _garage.ParkCar(car);

            Assert.NotNull(receipt);
        }

        [Test]
        public void ParkCar_should_give_a_parking_receipt_that_includes_parked_car()
        {
            var car = new Car { LicenseNumber = "ABC123" };
            ParkingReceipt receipt = _garage.ParkCar(car);

            Assert.AreSame(car, receipt.Car);
        }

        [Test]
        public void ParkCar_should_give_a_parking_receipt_that_includes_a_time_when_car_was_parked()
        {
            var car = new Car { LicenseNumber = "ABC123" };
            ParkingReceipt receipt = _garage.ParkCar(car);

            Assert.AreNotEqual(DateTime.MinValue, receipt.TimeParked);
        }

        [Test]
        public void Checkout_should_return_a_invoice()
        {
            var car = new Car { LicenseNumber = "ABC123" };
            ParkingReceipt receipt = _garage.ParkCar(car);

            var invoice = _garage.Checkout(receipt);

            Assert.NotNull(invoice);
        }

        [Test]
        public void Checkout_should_remove_car_from_garage()
        {
            var car = new Car { LicenseNumber = "ABC123" };
            ParkingReceipt receipt = _garage.ParkCar(car);

            _garage.Checkout(receipt);

            Assert.AreEqual(0, _garage.ParkedCars.Count());
        }
    }
}
