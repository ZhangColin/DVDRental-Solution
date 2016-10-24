namespace DVDRental.Subscription.RentalRequests.Events
{
    /// <summary>
    /// 租借电影请求
    /// </summary>
    public class FilmRequested
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
        public string RequestId { get; set; }
    }
}