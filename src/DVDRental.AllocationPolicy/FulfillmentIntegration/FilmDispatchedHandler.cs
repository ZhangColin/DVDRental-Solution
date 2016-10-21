using System;
using DVDRenatal.Infrastructure.Domain;
using DVDRenatal.Infrastructure.Messages;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Fulfillment.Contracts.Events;
using DVDRental.Subscription.RentalHistory;
using DVDRental.Subscription.RentalRequests;
using DVDRental.Subscription.RentalRequests.Events;

namespace DVDRental.AllocationPolicy.FulfillmentIntegration
{
    public class FilmDispatchedHandler: IMessageHandler<FilmDispatched>
    {
        private readonly IRentalRequestRepository _rentalRequestRepository;
        private readonly IRepository<Rental> _rentalRepository;
        private readonly IMessageBus _messageBus;

        public FilmDispatchedHandler(IRentalRequestRepository rentalRequestRepository, IRepository<Rental> rentalRepository, IMessageBus messageBus)
        {
            _rentalRequestRepository = rentalRequestRepository;
            _rentalRepository = rentalRepository;
            _messageBus = messageBus;
        }

        public void Execute(FilmDispatched message)
        {
            var rentalRequestList = _rentalRequestRepository.FindBy(message.SubscriptionId);

            using (DomainEvents.Register((RequestFulfilled s) =>
            {
                // Should add film name
                //_bus.Publish(new AddRentalHistory() { FilmId = s.FilmId, SubscriptionId = s.SubscriptionId });

                // TODO: Send command
                var rental = new Rental(s.FilmId, s.SubscriptionId, DateTime.Now);
                _rentalRepository.Add(rental);
            }))
            {
                rentalRequestList.Fulfilled(message.FilmId);
                _rentalRequestRepository.Save(rentalRequestList);
            }
        }
    }
}