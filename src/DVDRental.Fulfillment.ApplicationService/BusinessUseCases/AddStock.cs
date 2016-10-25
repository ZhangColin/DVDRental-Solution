using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Fulfillment.ApplicationService.BusinessUseCases
{
    /// <summary>
    /// 添加库存（添加一部Dvd）
    /// </summary>
    public class AddStock: ICommand
    {
        public int FilmId { get; set; }
        public string Barcode { get; set; }
    }
}