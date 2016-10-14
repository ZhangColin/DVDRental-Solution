using System;
using System.Collections.Generic;
using DVDRental.Catalogue.Catalogue;

namespace DVDRental.Operational.ApplicationService
{
    public class OperationService
    {
        public IEnumerable<Film> ViewAllFilms()
        {
            return new[]
            {
                new Film(DateTime.Now, "Film 1"),
                new Film(DateTime.Now, "Film 2"),
            };
        }
    }
}