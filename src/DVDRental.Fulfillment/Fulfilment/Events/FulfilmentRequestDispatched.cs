namespace DVDRental.Fulfillment.Fulfilment.Events
{
    /// <summary>
    /// 满足请求，Dvd已派送
    /// </summary>
    public class FulfilmentRequestDispatched
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
        public int DvdId { get; set; }
    }
}