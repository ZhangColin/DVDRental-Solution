using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Fulfillment.Contracts.Events
{
    public class FilmBeingPicked : IMessage
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}