
using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Subscription.ApplicationService.BusinessUseCases
{
    /// <summary>
    /// 客户想租借一部电影
    /// </summary>
    public class CustomerWantsToRentAFilm: ICommand
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}