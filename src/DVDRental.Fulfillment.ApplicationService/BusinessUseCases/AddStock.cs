using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Fulfillment.ApplicationService.BusinessUseCases
{
    public class AddStock: ICommand
    {
        public int FilmId { get; set; }
        public string Barcode { get; set; }
    }
}