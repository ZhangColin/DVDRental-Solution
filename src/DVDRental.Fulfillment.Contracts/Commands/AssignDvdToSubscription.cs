using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Fulfillment.Contracts.Commands
{
    /// <summary>
    /// 分配Dvd给会员
    /// </summary>
    public class AssignDvdToSubscription : IMessage
    {
        public int SubscriptionId { get; set; }
        public int DvdId { get; set; }
    }
}