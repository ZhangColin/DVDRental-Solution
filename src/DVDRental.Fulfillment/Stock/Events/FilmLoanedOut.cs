namespace DVDRental.Fulfillment.Stock.Events {
    public class FilmLoanedOut
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}