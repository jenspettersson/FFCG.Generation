namespace FFCG.Garage.Pricing.PriceRules
{
    using System;

    public class OneHourPriceRule : IParkingPriceRule
    {
        private readonly decimal _rateThisHour;

        public OneHourPriceRule()
        {
            _rateThisHour = 10m;
        }

        public decimal Amount(TimeSpan time)
        {
            var total = 0m;

            if (time.Hours >= 1)
            {
                total += _rateThisHour;
            }
            else
            {
                total += CalculateCostForMinutes(time);
            }

            return total;
        }

        private decimal CalculateCostForMinutes(TimeSpan time)
        {
            return (time.Minutes / 60.0m) * _rateThisHour;
        }
    }
}