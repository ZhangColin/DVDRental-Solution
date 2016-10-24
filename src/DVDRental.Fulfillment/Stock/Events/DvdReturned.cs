namespace DVDRental.Fulfillment.Stock.Events {
    /// <summary>
    /// Dvd被归还
    /// </summary>
    public class DvdReturned
    {
        public int FilmId { get; set; }
        public int Subscription { get; set; }
    }
}