namespace FFCG.Garage.Pricing.PriceRules
{
    using System;

    public class ThreeOrMoreHoursPriceRule : IParkingPriceRule
    {
        private readonly decimal _rateThisHour;

        public ThreeOrMoreHoursPriceRule()
        {
            _rateThisHour = 4m;
        }

        public decimal Amount(TimeSpan time)
        {
            var total = 0m;

            if (time.Hours >= 3)
            {
                int remainingHours = time.Hours - 2;

                total += _rateThisHour * remainingHours;   
            }

            if (time.Hours >= 2 && time.Minutes > 0)
                total += CalculateCostForMinutes(time);

            return total;
        }

        private decimal CalculateCostForMinutes(TimeSpan time)
        {
            return (time.Minutes / 60.0m) * _rateThisHour;
        }
    }
}