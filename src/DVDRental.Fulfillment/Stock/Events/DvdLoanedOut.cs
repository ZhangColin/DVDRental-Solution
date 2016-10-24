namespace DVDRental.Fulfillment.Stock.Events {
    /// <summary>
    /// Dvd被借出
    /// </summary>
    public class DvdLoanedOut
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}