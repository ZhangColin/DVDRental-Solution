using System;
using System.Web.Mvc;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;
using DVDRental.Operational.UI.Models;

namespace DVDRental.Operational.UI.Controllers {
    /// <summary>
    /// 添加电影
    /// </summary>
    public class AddFilmController: Controller {
        private readonly ICommandBus _commandBus;

        public AddFilmController(ICommandBus commandBus) {
            _commandBus = commandBus;
        }

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FilmModel filmModel)
        {
            _commandBus.Submit(new AddFilmToCatalogue()
            {
                ReleaseDate = DateTime.Now,
                Title = filmModel.Title
            });

            return RedirectToAction("FilmAdded", new {Title = filmModel.Title});
        }

        public ActionResult FilmAdded(string title)
        {
            var filmAdded = new FilmAddedModel();
            filmAdded.Title = title;

            return View(filmAdded);
        }
    }
}