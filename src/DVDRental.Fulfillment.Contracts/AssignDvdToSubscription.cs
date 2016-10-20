using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Fulfillment.Contracts
{
    public class AssignDvdToSubscription : IMessage
    {
        public int SubscriptionId { get; set; }
        public int DvdId { get; set; }
    }
}