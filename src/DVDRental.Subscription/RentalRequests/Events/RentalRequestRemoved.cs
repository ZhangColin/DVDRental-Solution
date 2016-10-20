namespace DVDRental.Subscription.RentalRequests.Events
{
    public class RentalRequestRemoved
    {
        public int FilmId { get; set; }
        public int MemberId { get; set; }
    }
}