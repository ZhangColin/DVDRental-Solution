using System.Web.Mvc;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;
using DVDRental.Operational.ApplicationService;

namespace DVDRental.Operational.UI.Controllers
{
    public class ReturnsController: Controller
    {
        private readonly OperationService _operationService;
        private readonly ICommandBus _commandBus;

        public ReturnsController(OperationService operationService, ICommandBus commandBus)
        {
            _operationService = operationService;
            _commandBus = commandBus;
        }

        public ActionResult Index()
        {
            var returns = _operationService.ViewAllPotentialReturns();
            return View(returns);
        }

        public ActionResult ReturnProcessed()
        {
            return View();
        }

        public ActionResult Process(int dvdId)
        {
            _commandBus.Submit(new ReturnAFilm() {DvdId = dvdId});

            return RedirectToAction("ReturnProcessed");
        }
    }
}