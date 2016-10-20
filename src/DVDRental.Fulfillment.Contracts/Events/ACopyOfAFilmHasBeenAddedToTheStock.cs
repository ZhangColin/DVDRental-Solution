using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Fulfillment.Contracts.Events
{
    public class ACopyOfAFilmHasBeenAddedToTheStock: IMessage
    {
        public  int FilmId { get; set; }
    }
}