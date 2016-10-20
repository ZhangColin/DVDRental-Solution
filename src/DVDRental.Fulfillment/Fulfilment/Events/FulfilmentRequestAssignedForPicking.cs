namespace DVDRental.Fulfillment.Fulfilment.Events
{
    public class FulfilmentRequestAssignedForPicking
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}