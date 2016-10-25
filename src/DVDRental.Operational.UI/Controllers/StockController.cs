using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;
using DVDRental.Fulfillment.Stock;
using DVDRental.Operational.ApplicationService;
using DVDRental.Operational.UI.Models;

namespace DVDRental.Operational.UI.Controllers
{
    /// <summary>
    /// 库存管理
    /// </summary>
    public class StockController: Controller
    {
        private readonly OperationService _operationService;
        private readonly ICommandBus _commandBus;

        public StockController(OperationService operationService, ICommandBus commandBus)
        {
            _operationService = operationService;
            _commandBus = commandBus;
        }

        public ActionResult ViewStockFor(int filmId)
        {
            var stockModel = new StockModel();
            IEnumerable<Dvd> stock = _operationService.ViewStockFor(filmId);

            stockModel.Stock = stock;
            stockModel.FilmId = filmId;

            return View(stockModel);
        }

        [HttpPost]
        public ActionResult AddStockFor(int filmId)
        {
            var barcode = Guid.NewGuid().ToString();
            _commandBus.Submit(new AddStock
            {
                FilmId = filmId,
                Barcode = barcode
            });

            return RedirectToAction("StockAdded", new {filmId, barcode});
        }

        public ActionResult StockAdded(int filmId, string barcode)
        {
            return View(new StockAddedModel()
            {
                FilmId = filmId,
                Barcode = barcode
            });
        }
    }
}