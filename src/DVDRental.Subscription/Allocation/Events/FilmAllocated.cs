namespace DVDRental.Subscription.Allocation.Events
{
    public class FilmAllocated
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}