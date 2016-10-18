using System.Threading.Tasks;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Catalogue.Catalogue;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;

namespace DVDRental.Fulfillment.ApplicationService.Handlers
{
    public class AddFilmToCatalogueHandler: ICommandHandler<AddFilmToCatalogue>
    {
        private readonly IRepository<Film> _filmRepository;

        public AddFilmToCatalogueHandler(IRepository<Film> filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public Task Execute(AddFilmToCatalogue command)
        {
            Film film = new Film(command.ReleaseDate, command.Title);

            return _filmRepository.AddAsync(film);
        }
    }
}