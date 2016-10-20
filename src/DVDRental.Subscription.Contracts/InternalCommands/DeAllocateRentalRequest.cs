using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Subscription.Contracts.InternalCommands
{
    public class DeAllocateRentalRequest: IMessage
    {
        public int SubscriptionId { get; set; }
        public int FilmId { get; set; }
    }
}