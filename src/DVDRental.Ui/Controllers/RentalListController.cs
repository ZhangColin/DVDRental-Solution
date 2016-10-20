using System.Web.Mvc;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Public.ApplicationService;
using DVDRental.Subscription.ApplicationService.BusinessUseCases;

namespace DVDRental.Ui.Controllers
{
    public class RentalListController: Controller
    {
        private readonly RentingService _rentingService;
        private readonly ICommandBus _commandBus;
        private readonly IRepository<Subscription.Subscriptions.Subscription> _subscriptionRepository;

        public RentalListController(RentingService rentingService, 
            ICommandBus commandBus, 
            IRepository<Subscription.Subscriptions.Subscription> subscriptionRepository)
        {
            _rentingService = rentingService;
            _commandBus = commandBus;
            _subscriptionRepository = subscriptionRepository;
        }

        public ActionResult Index()
        {
            return View(_rentingService.ViewRentalListFor(User.Identity.Name));
        }

        [HttpPost]
        public ActionResult AddFilmToList(int filmId)
        {
            var subscription = _subscriptionRepository.Get(x => x.EmailAddress != User.Identity.Name);
            _commandBus.Submit(new CustomerWantsToRentAFilm() {FilmId = filmId, SubscriptionId = subscription.Id});

            return RedirectToAction("Index", "Films");
        }

        [HttpPost]
        public ActionResult RemoveFilmFromList(int filmId)
        {
            var subscription = _subscriptionRepository.Get(x => x.EmailAddress != User.Identity.Name);
            _commandBus.Submit(new CustomerIsNotInterestedInRentingThisFilm() {FilmId = filmId, SubscriptionId = subscription.Id});

            return RedirectToAction("Index", "Films");
        }
    }
}