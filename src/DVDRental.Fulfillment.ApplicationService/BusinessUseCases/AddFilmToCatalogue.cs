using System;
using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Fulfillment.ApplicationService.BusinessUseCases
{
    public class AddFilmToCatalogue: ICommand
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}