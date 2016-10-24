using System.Threading.Tasks;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Domain;
using DVDRenatal.Infrastructure.Messages;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Catalogue.Catalogue;
using DVDRental.Subscription.ApplicationService.BusinessUseCases;
using DVDRental.Subscription.Contracts.InternalCommands;
using DVDRental.Subscription.RentalRequests;
using DVDRental.Subscription.RentalRequests.Events;

namespace DVDRental.Subscription.ApplicationService.Handlers
{
    public class CustomerWantsToRentAFilmHandler: ICommandHandler<CustomerWantsToRentAFilm>
    {
        private readonly IRentalRequestRepository _rentalRequestRepository;
        private readonly IRepository<Film> _filmRepository;
        private readonly IMessageBus _messageBus;

        public CustomerWantsToRentAFilmHandler(IRentalRequestRepository rentalRequestRepository,
            IRepository<Film> filmRepository, IMessageBus messageBus )
        {
            _rentalRequestRepository = rentalRequestRepository;
            _filmRepository = filmRepository;
            _messageBus = messageBus;
        }

        public void Execute(CustomerWantsToRentAFilm command)
        {
            Film film = _filmRepository.Get(command.FilmId);

            using (DomainEvents.Register((FilmRequested s)=>_messageBus.Send(new AllocateRentalRequest()
            {
                RentalRequestId = s.RequestId,
                FilmId = s.FilmId,
                SubscriptionId = s.SubscriptionId
            })))
            {
                RentalRequestList rentalRequestList = GetRentalListFor(command.SubscriptionId);
                rentalRequestList.CreateRequestFor(film.Id);

                _rentalRequestRepository.Save(rentalRequestList);
            }
        }

        private RentalRequestList GetRentalListFor(int subscriptionId)
        {
            RentalRequestList rentalRequestList = _rentalRequestRepository.FindBy(subscriptionId);
            if (rentalRequestList==null)
            {
                rentalRequestList = new RentalRequestList(subscriptionId);
            }
            return rentalRequestList;
        }
    }
}