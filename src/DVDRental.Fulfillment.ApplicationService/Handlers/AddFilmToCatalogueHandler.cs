using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Catalogue.Catalogue;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;

namespace DVDRental.Fulfillment.ApplicationService.Handlers
{
    /// <summary>
    /// 添加一部电影
    /// </summary>
    public class AddFilmToCatalogueHandler: ICommandHandler<AddFilmToCatalogue>
    {
        private readonly IRepository<Film> _filmRepository;

        public AddFilmToCatalogueHandler(IRepository<Film> filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public void Execute(AddFilmToCatalogue command)
        {
            Film film = new Film(command.ReleaseDate, command.Title);

            _filmRepository.Add(film);
        }
    }
}