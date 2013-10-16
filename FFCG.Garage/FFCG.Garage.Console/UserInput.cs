namespace FFCG.Garage.ConsoleRunner
{
    using System;
    using Checkout;

    public enum UserInput
    {
        ParkCar = 1,
        ExitCar = 2,
        ViewCars = 3,
        ShutDown = 4,
        Undefined
    }

    public class RandomTimeService : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            var random = new Random();
            int hour = random.Next(0, 12);
            int minute = random.Next(0, 60);

            return DateTime.Now.AddHours(hour).AddMinutes(minute);
        }
    }
}