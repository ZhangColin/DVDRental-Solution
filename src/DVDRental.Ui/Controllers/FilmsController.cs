using System.Web.Mvc;
using DVDRental.Public.ApplicationService;

namespace DVDRental.Ui.Controllers {
    public class FilmsController: Controller {
        private readonly RentingService _rentingService;

        public FilmsController(RentingService rentingService)
        {
            _rentingService = rentingService;
        }

        public ActionResult Index() {
            return View(_rentingService.CustomerWantsToViewFilmsAvailableForRent(User.Identity.Name));
        }
    }
}