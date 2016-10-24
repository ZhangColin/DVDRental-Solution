namespace DVDRental.Fulfillment.Fulfilment.Events
{
    /// <summary>
    /// 租借请求被选择
    /// </summary>
    public class FulfilmentRequestAssignedForPicking
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}