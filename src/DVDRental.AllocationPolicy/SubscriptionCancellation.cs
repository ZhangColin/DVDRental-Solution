using DVDRenatal.Infrastructure.Messages;
using DVDRental.Fulfillment.Contracts.Events;
using DVDRental.Subscription.Contracts;
using DVDRental.Subscription.Contracts.Events;

namespace DVDRental.AllocationPolicy
{
    public class SubscriptionCancellation: IMessageHandler<CannotCancelSubscription>
    {
        public void Execute(CannotCancelSubscription message)
        {
            // Start the saga (process manager)
        }

        public void Handle(SubscriptionCancelled message) {
            // kill the saga
        }

        public void Handle(FilmReturned message) {
            // Subscription.Cancel() // This will fire an event so that billing will cancel

            // Kill saga
        }

        public void Handle(CustomerWantsToKeepSubscription message) {
            // Kill saga
        }
    }
}