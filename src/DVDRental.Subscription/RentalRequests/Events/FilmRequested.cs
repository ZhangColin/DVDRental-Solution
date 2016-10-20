namespace DVDRental.Subscription.RentalRequests.Events
{
    public class FilmRequested
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
        public string Id { get; set; }
    }
}