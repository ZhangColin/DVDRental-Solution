using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Fulfillment.ApplicationService.BusinessUseCases
{
    /// <summary>
    /// 归还一部电影
    /// </summary>
    public class ReturnAFilm: ICommand
    {
        public int DvdId { get; set; }
    }
}