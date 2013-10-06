namespace FFCG.Garage.Checkout
{
    using System;
    using Pricing;

    public class CheckoutService
    {
        private readonly ITimeService _timeService;
        private IPriceCalculator _priceCalculator;

        public CheckoutService(IPriceCalculator priceCalculator) : this(new DefaultTimeService(), priceCalculator){ }

        public CheckoutService(ITimeService timeService, IPriceCalculator priceCalculator)
        {
            _timeService = timeService;
            _priceCalculator = priceCalculator;
        }

        public Invoice Checkout(ParkingReceipt parkingReceipt)
        {
            DateTime currentTime = _timeService.GetCurrentTime();
            TimeSpan totalTimeParked = currentTime - parkingReceipt.TimeParked;

            decimal amountToPay = _priceCalculator.Calculate(totalTimeParked);

            return new Invoice {HoursParked = totalTimeParked.Hours, MinutesParked = totalTimeParked.Minutes, TotalAmount = amountToPay};
        }
    }
}