namespace FFCG.Garage.ConsoleRunner
{
    using System.Collections.Generic;
    using Checkout;
    using Pricing;
    using Pricing.PriceRules;

    public static class Configure
    {
        public static Garage DefaultGarage()
        {
            var checkoutService = new CheckoutService(new DefaultTimeService(), GetPriceCalculator());
            return new Garage(checkoutService);
        }

        public static Garage GarageWithRandomTime()
        {
            
            var checkoutService = new CheckoutService(new RandomTimeService(), GetPriceCalculator());
            return new Garage(checkoutService);
        }

        private static PriceCalculator GetPriceCalculator()
        {
            return new PriceCalculator(new List<IParkingPriceRule>
                {
                    new OneHourPriceRule(),
                    new TwoHourPriceRule(),
                    new ThreeOrMoreHoursPriceRule()
                });
        }
    }
}