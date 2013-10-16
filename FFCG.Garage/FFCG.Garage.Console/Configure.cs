namespace FFCG.Garage.ConsoleRunner
{
    using Checkout;
    using Pricing;

    public static class Configure
    {
        public static Garage DefaultGarage()
        {
            return new Garage();
        }

        public static Garage GarageWithRandomTime()
        {
            var checkoutService = new CheckoutService(new RandomTimeService(), new PriceCalculator());
            return new Garage(checkoutService);
        }
    }
}