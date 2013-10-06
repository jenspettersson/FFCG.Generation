namespace FFCG.Garage
{
    using System.Collections.Generic;

    public class Garage
    {
        private readonly List<Car> _parkedCars;
        public IEnumerable<Car> ParkedCars
        {
            get { return _parkedCars; }
        }

        public Garage()
        {
            _parkedCars = new List<Car>();
        }


        public ParkingReceipt ParkCar(Car car)
        {
            _parkedCars.Add(car);

            return ParkingReceipt.Create().ForCar(car);
        }
    }
}
