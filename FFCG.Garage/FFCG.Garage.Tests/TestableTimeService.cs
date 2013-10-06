namespace FFCG.Garage.Tests
{
    using System;
    using Checkout;

    public class TestableTimeService : ITimeService
    {
        private readonly DateTime _currentTime;

        public TestableTimeService(DateTime currentTime)
        {
            _currentTime = currentTime;
        }

        public DateTime GetCurrentTime()
        {
            return _currentTime;
        }
    }
}