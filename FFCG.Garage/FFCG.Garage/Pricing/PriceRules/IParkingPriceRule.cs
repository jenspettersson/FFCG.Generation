namespace FFCG.Garage.Pricing.PriceRules
{
    using System;

    public interface IParkingPriceRule
    {
        decimal Amount(TimeSpan time);
    }
}