using DVDRenatal.Infrastructure.Domain;

namespace DVDRental.Subscription.Allocation
{
    /// <summary>
    /// 分配会员
    /// </summary>
    public class SubscriptionAllocation: Entity<int>
    {
        public int SubscriptionId { get; set; }
    }
}