namespace FFCG.Garage.Pricing.PriceRules
{
    using System;

    public class TwoHourPriceRule : IParkingPriceRule
    {
        private readonly decimal _rateThisHour;

        public TwoHourPriceRule()
        {
            _rateThisHour = 6m;
        }

        public decimal Amount(TimeSpan time)
        {
            var total = 0m;

            if (time.Hours >= 2)
            {
                total += _rateThisHour;
            }
            
            if(time.Hours == 2)
                total += (time.Minutes / 60.0m) * _rateThisHour;
            
            
            return total;
        }
    }
}