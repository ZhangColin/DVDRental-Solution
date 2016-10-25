using DVDRenatal.Infrastructure.Repository;
using DVDRental.Subscription.RentalRequests;

namespace DVDRental.Public.ApplicationService
{
    /// <summary>
    /// 会员服务
    /// </summary>
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

        /// <summary>
        /// email是否已经被已有的会员使用
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool AlreadyHaveSubscriptionWithEmail(string email)
        {
            return _subscriptionRepository.Get(x => x.EmailAddress == email) != null;
        }

        /// <summary>
        /// 通过email获取会员
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Subscription.Subscriptions.Subscription GetSubscriptionWithEmail(string email)
        {
            return _subscriptionRepository.Get(x => x.EmailAddress == email);
        }
    }
}