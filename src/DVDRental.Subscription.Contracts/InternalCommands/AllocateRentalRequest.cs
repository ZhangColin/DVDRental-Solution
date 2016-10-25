
using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Subscription.Contracts.InternalCommands
{
    /// <summary>
    /// 分配租借申请
    /// </summary>
    public class AllocateRentalRequest: IMessage
    {
        public int SubscriptionId { get; set; }
        public int FilmId { get; set; }
        public string RentalRequestId { get; set; }
    }
}