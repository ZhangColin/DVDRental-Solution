using System.Collections.Generic;
using DVDRental.Public.ApplicationService.ApplicationViews;

namespace DVDRental.Public.ApplicationService {
    public class RentingService {
        public IEnumerable<FilmView> CustomerWantsToViewFilmsAvailableForRent(string memberEmail)
        {
            return new[]
            {
                new FilmView() {Id = 1, Name = "Film 1", IsCurrentlyOnLoan = true, IsOnRentalList = false},
                new FilmView() {Id = 2, Name = "Film 2", IsCurrentlyOnLoan = true, IsOnRentalList = false},
            };
        }
    }
}
