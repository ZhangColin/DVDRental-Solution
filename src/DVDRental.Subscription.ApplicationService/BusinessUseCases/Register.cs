using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Subscription.ApplicationService.BusinessUseCases
{
    /// <summary>
    /// 会员注册
    /// </summary>
    public class Register: ICommand
    {
        public string EmailAddress { get; set; }
        public int PackageId { get; set; }
    }
}