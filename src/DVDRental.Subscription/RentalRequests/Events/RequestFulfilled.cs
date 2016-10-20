namespace DVDRental.Subscription.RentalRequests.Events
{
    public class RequestFulfilled
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}