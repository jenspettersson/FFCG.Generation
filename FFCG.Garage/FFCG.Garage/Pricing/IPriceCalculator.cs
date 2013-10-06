namespace FFCG.Garage.Pricing
{
    using System;

    public interface IPriceCalculator
    {
        decimal Calculate(TimeSpan timeSpan);
    }
}