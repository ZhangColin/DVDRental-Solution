using System.Web.Mvc;
using DVDRental.Operational.ApplicationService;

namespace DVDRental.Operational.UI.Controllers {
    /// <summary>
    /// 电影列表
    /// </summary>
    public class FilmController: Controller {
        private readonly OperationService _operationService;

        public FilmController(OperationService operationService)
        {
            _operationService = operationService;
        }

        public ActionResult Index() {
            return View(_operationService.ViewAllFilms());
        }
    }
}