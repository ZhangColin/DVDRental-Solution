using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Fulfillment.ApplicationService.BusinessUseCases
{
    public class ReturnAFilm: ICommand
    {
        public int DvdId { get; set; }
    }
}