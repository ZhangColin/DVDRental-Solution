using DVDRenatal.Infrastructure.Repository;
using DVDRental.Subscription.RentalRequests;

namespace DVDRental.Public.ApplicationService
{
    public class SubscriptionService
    {
        private readonly IRepository<Subscription.Subscriptions.Subscription> _subscriptionRepository;
        private readonly IRentalRequestRepository _rentalRequestRepository;

        public SubscriptionService(IRepository<Subscription.Subscriptions.Subscription> subscriptionRepository,
            IRentalRequestRepository rentalRequestRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _rentalRequestRepository = rentalRequestRepository;
        }

        public void CustomerWantsToCancelSubscription(int subscriptionId)
        {
            
        }

        public void CustomerWantsToChangeSubscription(int subscriptionId)
        {
            
        }

        public void CustomerWantsToTakeAPaymentHoliday(int subscriptionId)
        {
            
        }

        public bool AlreadyHaveSubscriptionWithEmail(string email)
        {
            return _subscriptionRepository.Get(x => x.EmailAddress == email) != null;
        }

        public Subscription.Subscriptions.Subscription GetSubscriptionWithEmail(string email)
        {
            return _subscriptionRepository.Get(x => x.EmailAddress == email);
        }
    }
}