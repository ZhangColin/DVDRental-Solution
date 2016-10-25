using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Subscription.ApplicationService.BusinessUseCases
{
    /// <summary>
    /// 客户无意租借这部电影
    /// </summary>
    public class CustomerIsNotInterestedInRentingThisFilm: ICommand {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}