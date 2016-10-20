namespace DVDRental.Fulfillment.Fulfilment.Events
{
    public class FulfilmentRequestDispatched
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
        public int DvdId { get; set; }
    }
}