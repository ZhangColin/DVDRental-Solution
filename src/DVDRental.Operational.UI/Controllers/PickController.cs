using System.Web.Mvc;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;
using DVDRental.Operational.ApplicationService;
using DVDRental.Operational.ApplicationService.ApplicationViews;
using DVDRental.Operational.UI.Models;

namespace DVDRental.Operational.UI.Controllers
{
    /// <summary>
    /// 选中
    /// </summary>
    public class PickController: Controller
    {
        private readonly OperationService _operationService;
        private readonly ICommandBus _commandBus;

        public PickController(OperationService operationService, ICommandBus commandBus)
        {
            _operationService = operationService;
            _commandBus = commandBus;
        }

        public ActionResult Index()
        {
            PickListView pickListView = _operationService.OperatorWantsToViewAssignedRentalAllocations("Colin");
            return View(pickListView);
        }

        [HttpPost]
        public ActionResult Assign()
        {
            _commandBus.Submit(new AssignRentalAllocationsToPicker() {PickerName = "Colin"});

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Dispatch(DvdAssignmentModel form)
        {
            _commandBus.Submit(new MarkRentalAllocationAsDispatched()
            {
                PickerName = "Colin",
                DvdId = form.DvdId,
                FulfilmentRequestId = form.FulfilmentRequestId
            });

            return RedirectToAction("Index");
        }

    }
}