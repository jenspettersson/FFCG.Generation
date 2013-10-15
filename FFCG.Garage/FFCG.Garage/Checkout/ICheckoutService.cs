namespace FFCG.Garage.Checkout
{
    public interface ICheckoutService
    {
        Invoice Checkout(ParkingReceipt parkingReceipt);
    }
}