using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Subscription.ApplicationService.BusinessUseCases
{
    public class CustomerIsNotInterestedInRentingThisFilm: ICommand {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}