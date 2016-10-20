using System.Collections.Generic;
using System.Linq;
using DVDRenatal.Infrastructure.AutoMapper;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Catalogue.Catalogue;
using DVDRental.Public.ApplicationService.ApplicationViews;
using DVDRental.Subscription.RentalHistory;
using DVDRental.Subscription.RentalRequests;

namespace DVDRental.Public.ApplicationService {
    public class RentingService {
        private readonly IRepository<Subscription.Subscriptions.Subscription> _subscriptionRepository;
        private readonly IRepository<Rental> _rentalRepository;
        private readonly IRepository<Film> _filmRepository;
        private readonly IRentalRequestRepository _rentalRequestRepository;

        public RentingService(IRepository<Subscription.Subscriptions.Subscription> subscriptionRepository, 
            IRepository<Rental> rentalRepository,
            IRepository<Film> filmRepository,
            IRentalRequestRepository rentalRequestRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _rentalRepository = rentalRepository;
            _filmRepository = filmRepository;
            _rentalRequestRepository = rentalRequestRepository;
        }

        public IEnumerable<FilmView> CustomerWantsToViewFilmsAvailableForRent(string member)
        {
            var films = _filmRepository.All().Take(10).AsEnumerable();
            return films.MapTo<IEnumerable<FilmView>>();
        }

        public IEnumerable<Rental> GetRentalHistoryFor(string member)
        {
            var subscription = _subscriptionRepository.Query(x => x.EmailAddress == member).FirstOrDefault();
            return _rentalRepository.Query(x => x.SubscriptionId == subscription.Id).Take(100).AsEnumerable();
        }

        public IEnumerable<RentalRequestView> ViewRentalListFor(string member)
        {
            var subscription = _subscriptionRepository.Get(x=>x.EmailAddress==member);
            var rentalRequestList = _rentalRequestRepository.FindBy(subscription.Id);
            return rentalRequestList.RentalRequests.MapTo<IEnumerable<RentalRequestView>>();
        }
    }
}
