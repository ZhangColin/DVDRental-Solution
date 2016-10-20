namespace DVDRental.Fulfillment.Stock.Events {
    public class FilmReturned
    {
        public int FilmId { get; set; }
        public int Subscription { get; set; }
    }
}