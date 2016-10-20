using DVDRenatal.Infrastructure.Messages;
using DVDRental.Fulfillment.Contracts.Commands;
using DVDRental.Fulfillment.Contracts.Events;

namespace DVDRental.FulfillmentPolicy.WebEventForwarding
{
    public class PublishThatACopyOfAFilmHasBeenAddedToTheStockHandler: IMessageHandler<PublishThatACopyOfAFilmHasBeenAddedToTheStock>
    {
        private readonly IMessageBus _messageBus;

        public PublishThatACopyOfAFilmHasBeenAddedToTheStockHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void Execute(PublishThatACopyOfAFilmHasBeenAddedToTheStock message)
        {
            _messageBus.Send(new ACopyOfAFilmHasBeenAddedToTheStock() {FilmId = message.FilmId});
        }
    }
}