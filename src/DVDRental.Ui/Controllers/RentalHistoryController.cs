using System.Web.Mvc;
using DVDRental.Public.ApplicationService;

namespace DVDRental.Ui.Controllers
{
    public class RentalHistoryController: Controller
    {
        private readonly RentingService _rentingService;

        public RentalHistoryController(RentingService rentingService)
        {
            _rentingService = rentingService;
        }

        public ActionResult Index()
        {
            return View(_rentingService.GetRentalHistoryFor(User.Identity.Name));
        }
    }
}