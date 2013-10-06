namespace FFCG.Garage
{
    using System;

    public class ParkingReceipt
    {
        public Car Car { get; private set; }
        public DateTime TimeParked { get; private set; }
        
        private ParkingReceipt()
        {
            TimeParked = DateTime.Now;
        }

        private ParkingReceipt(DateTime timeParked)
        {
            TimeParked = timeParked;
        }

        public static ParkingReceipt Create()
        {
            return new ParkingReceipt();
        }
        public static ParkingReceipt Create(DateTime timeParked)
        {
            return new ParkingReceipt(timeParked);
        }

        public ParkingReceipt ForCar(Car car)
        {
            Car = car;
            return this;
        }
    }
}