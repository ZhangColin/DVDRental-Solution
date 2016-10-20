using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Subscription.ApplicationService.BusinessUseCases
{
    public class Register: ICommand
    {
        public string EmailAddress { get; set; }
        public int PackageId { get; set; }
    }
}