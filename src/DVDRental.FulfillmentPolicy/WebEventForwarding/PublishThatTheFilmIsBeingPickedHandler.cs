using DVDRenatal.Infrastructure.Messages;
using DVDRental.Fulfillment.Contracts.Commands;
using DVDRental.Fulfillment.Contracts.Events;

namespace DVDRental.FulfillmentPolicy.WebEventForwarding
{
    public class PublishThatTheFilmIsBeingPickedHandler: IMessageHandler<PublishThatTheFilmIsBeingPicked>
    {
        private readonly IMessageBus _messageBus;

        public PublishThatTheFilmIsBeingPickedHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void Execute(PublishThatTheFilmIsBeingPicked message)
        {
            _messageBus.Send(new FilmBeingPicked()
            {
                FilmId = message.FilmId,
                SubscriptionId = message.SubscriptionId
            });
        }
    }
}