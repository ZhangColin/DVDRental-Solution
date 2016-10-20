using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Subscription.Contracts.Events
{
    public class FilmHasBeenAllocated: IMessage
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}