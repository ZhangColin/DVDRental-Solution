using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Fulfillment.Contracts.Events
{
    public class FilmDispatched: IMessage
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}