using System.Web.Mvc;

namespace DVDRental.Operational.UI.Controllers {
    public class HomeController: Controller {
        public ActionResult Index() {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
    }
}