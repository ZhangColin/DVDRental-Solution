using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Domain;
using DVDRenatal.Infrastructure.Messages;
using DVDRental.Subscription.ApplicationService.BusinessUseCases;
using DVDRental.Subscription.Contracts.InternalCommands;
using DVDRental.Subscription.RentalRequests;
using DVDRental.Subscription.RentalRequests.Events;

namespace DVDRental.Subscription.ApplicationService.Handlers
{
    /// <summary>
    /// 客户无意租借这部电影
    /// </summary>
    public class CustomerIsNotInterestedInRentingThisFilmHandler: ICommandHandler<CustomerIsNotInterestedInRentingThisFilm>
    {
        private readonly IRentalRequestRepository _rentalRequestRepository;
        private readonly IMessageBus _messageBus;

        public CustomerIsNotInterestedInRentingThisFilmHandler(IRentalRequestRepository rentalRequestRepository, IMessageBus messageBus)
        {
            _rentalRequestRepository = rentalRequestRepository;
            _messageBus = messageBus;
        }

        public void Execute(CustomerIsNotInterestedInRentingThisFilm command)
        {
            RentalRequestList rentalRequestList = _rentalRequestRepository.FindBy(command.SubscriptionId);
            using (DomainEvents.Register((RentalRequestRemoved s)=>_messageBus.Send(new DeAllocateRentalRequest()
            {
                FilmId = command.FilmId,
                SubscriptionId = command.SubscriptionId
            })))
            {
                rentalRequestList.RemoveFromTheList(command.FilmId);

                _rentalRequestRepository.Save(rentalRequestList);
            }
        }
    }
}