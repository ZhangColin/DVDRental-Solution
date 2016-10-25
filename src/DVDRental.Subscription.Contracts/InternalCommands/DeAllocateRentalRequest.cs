using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Subscription.Contracts.InternalCommands
{
    /// <summary>
    /// 取消分配租借申请
    /// </summary>
    public class DeAllocateRentalRequest: IMessage
    {
        public int SubscriptionId { get; set; }
        public int FilmId { get; set; }
    }
}