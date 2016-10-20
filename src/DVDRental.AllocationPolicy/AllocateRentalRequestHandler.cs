using DVDRenatal.Infrastructure.Domain;
using DVDRenatal.Infrastructure.Messages;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Subscription.Allocation;
using DVDRental.Subscription.Allocation.Events;
using DVDRental.Subscription.Contracts.Events;
using DVDRental.Subscription.Contracts.InternalCommands;
using DVDRental.Subscription.RentalHistory;
using DVDRental.Subscription.Subscriptions;

namespace DVDRental.AllocationPolicy
{
    public class AllocateRentalRequestHandler: IMessageHandler<AllocateRentalRequest>
    {
        private readonly IRepository<Subscription.Subscriptions.Subscription> _subscriptionRepository;
        private readonly IRepository<Rental> _rentalRepository;
        private readonly IRepository<Allocation> _allocationRepository;
        private readonly IMessageBus _messageBus;

        public AllocateRentalRequestHandler(IRepository<Subscription.Subscriptions.Subscription> subscriptionRepository,
            IRepository<Rental> rentalRepository, IRepository<Allocation> allocationRepository, IMessageBus messageBus)
        {
            _subscriptionRepository = subscriptionRepository;
            _rentalRepository = rentalRepository;
            _allocationRepository = allocationRepository;
            _messageBus = messageBus;
        }

        public void Execute(AllocateRentalRequest message)
        {
            var subscription = _subscriptionRepository.Get(message.SubscriptionId);

            if (subscription!=null)
            {
                //var currentPeriodRentals = _rentalRepository.FindRentalsForCurrentBillingPeriod();
                var currentPeriodRentals = new CurrentPeriodRentals();
                var currentAllocations = _allocationRepository.Query(x => x.HasAllocatedFor(message.SubscriptionId));
                Allocation allocation = _allocationRepository.Get(message.FilmId);

                using (DomainEvents.Register((FilmAllocated s)=>_messageBus.Send(new FilmHasBeenAllocated()
                {
                    FilmId = s.FilmId,
                    SubscriptionId = s.SubscriptionId
                })))
                {
                    new AllocationService().Allocate(subscription, currentPeriodRentals, currentAllocations, allocation);
                }
            }
        }
    }
}