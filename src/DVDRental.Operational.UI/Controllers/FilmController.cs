using System.Web.Mvc;
using DVDRental.Operational.ApplicationService;

namespace Agatha.DVDRental.Operational.UI.Controllers {
    public class FilmController: Controller {
        public ActionResult Index() {
            return View(new OperationService().ViewAllFilms());
        }
    }
}