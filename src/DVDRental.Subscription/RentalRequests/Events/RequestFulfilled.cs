namespace DVDRental.Subscription.RentalRequests.Events
{
    /// <summary>
    /// 租借请求已满足
    /// </summary>
    public class RequestFulfilled
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}