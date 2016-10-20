
using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Subscription.Contracts.InternalCommands
{
    public class AllocateRentalRequest: IMessage
    {
        public int SubscriptionId { get; set; }
        public int FilmId { get; set; }
        public string RentalRequestId { get; set; }
    }
}