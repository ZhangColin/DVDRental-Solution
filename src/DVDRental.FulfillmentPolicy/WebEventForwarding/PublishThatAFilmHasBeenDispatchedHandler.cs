using DVDRenatal.Infrastructure.Messages;
using DVDRental.Fulfillment.Contracts.Commands;
using DVDRental.Fulfillment.Contracts.Events;

namespace DVDRental.FulfillmentPolicy.WebEventForwarding
{
    public class PublishThatAFilmHasBeenDispatchedHandler: IMessageHandler<PublishThatAFilmHasBeenDispatched>
    {
        private readonly IMessageBus _messageBus;

        public PublishThatAFilmHasBeenDispatchedHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void Execute(PublishThatAFilmHasBeenDispatched message)
        {
            _messageBus.Send(new FilmDispatched()
            {
                FilmId = message.FilmId, SubscriptionId = message.SubscriptionId
            });
        }
    }
}