
using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Subscription.ApplicationService.BusinessUseCases
{
    public class CustomerWantsToRentAFilm: ICommand
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}