using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Fulfillment.Contracts.Commands
{
    public class PublishThatAFilmHasBeenDispatched : IMessage
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}