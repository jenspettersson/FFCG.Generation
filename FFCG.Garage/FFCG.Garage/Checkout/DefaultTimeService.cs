namespace FFCG.Garage.Checkout
{
    using System;

    public class DefaultTimeService : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}