using System;
using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Fulfillment.ApplicationService.BusinessUseCases
{
    /// <summary>
    /// 添加一部电影
    /// </summary>
    public class AddFilmToCatalogue: ICommand
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}