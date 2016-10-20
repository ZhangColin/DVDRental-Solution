namespace DVDRental.Subscription.RentalRequests
{
    public interface IRentalRequestRepository
    {
        RentalRequestList FindBy(int subscriptionId);
        void Add(RentalRequestList request);
    }
}