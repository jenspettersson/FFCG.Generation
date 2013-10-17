namespace FFCG.Garage
{
    using System.Collections.Generic;
    using Checkout;

    public class Garage
    {
        private readonly ICheckoutService _checkoutService;

        // This is exposes the parked cars as an IEnumerable ot prevent users of this class to modify the
        // list of cars without using the ParkCar/Checkout behaviour.
        private readonly List<Car> _parkedCars;
        public IEnumerable<Car> ParkedCars
        {
            get { return _parkedCars; }
        }

        public Garage(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
            _parkedCars = new List<Car>();
        }

        public ParkingReceipt ParkCar(Car car)
        {
            _parkedCars.Add(car);

            return ParkingReceipt.Create().ForCar(car);
        }

        public Invoice Checkout(ParkingReceipt receipt)
        {
            var invoice = _checkoutService.Checkout(receipt);

            _parkedCars.Remove(receipt.Car);

            return invoice;
        }
    }
}
