namespace FFCG.Garage.Pricing
{
    using System;
    using System.Collections.Generic;
    using PriceRules;

    public class PriceCalculator : IPriceCalculator
    {
        private readonly IEnumerable<IParkingPriceRule> _parkingPriceRules;
        
        // Creates a default list of Parking Price Rule if the consumer doesn't want to
        // supply their own rules
        public PriceCalculator() : this(new List<IParkingPriceRule>
            {
                new OneHourPriceRule(),
                new TwoHourPriceRule(),
                new ThreeOrMoreHoursPriceRule()
            }) {}

        public PriceCalculator(IEnumerable<IParkingPriceRule> parkingPriceRules)
        {
            _parkingPriceRules = parkingPriceRules;
        }

        public decimal Calculate(TimeSpan timeSpan)
        {
            decimal total = 0m;

            foreach (var rule in _parkingPriceRules)
            {
                total += rule.Amount(timeSpan);
            }

            return total;
        }
    }
}