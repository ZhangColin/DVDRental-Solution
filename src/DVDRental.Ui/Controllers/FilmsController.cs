using System.Web.Mvc;
using DVDRental.Public.ApplicationService;

namespace DVDRental.Ui.Controllers {
    public class FilmsController: Controller {
        public ActionResult Index() {
            return View(new RentingService().CustomerWantsToViewFilmsAvailableForRent(User.Identity.Name));
        }
    }
}