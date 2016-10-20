using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Fulfillment.Contracts.Commands
{
    public class PublishThatACopyOfAFilmHasBeenAddedToTheStock: IMessage
    {
        public int FilmId { get; set; }
    }
}