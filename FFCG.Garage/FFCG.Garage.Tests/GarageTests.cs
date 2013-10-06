namespace FFCG.Garage.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class GarageTests
    {
        private Garage _garage;

        [SetUp]
        public void SetUp()
        {
            _garage = new Garage();
        }

        [Test]
        public void ParkCar_should_put_one_car_in_the_garage()
        {
            //var car = new Car { LicenseNumber = "ABC123" };
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
    }
}
