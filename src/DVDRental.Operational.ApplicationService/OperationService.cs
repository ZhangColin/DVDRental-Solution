using System;
using System.Collections.Generic;
using System.Linq;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Catalogue.Catalogue;

namespace DVDRental.Operational.ApplicationService
{
    public class OperationService
    {
        private readonly IRepository<Film> _filmRepository;

        public OperationService(IRepository<Film> filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public IEnumerable<Film> ViewAllFilms()
        {
            // Take 10
            return _filmRepository.Query(film => true).AsEnumerable();
        }
    }
}