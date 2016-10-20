using DVDRenatal.Infrastructure.Domain;

namespace DVDRental.Subscription.Allocation
{
    public class SubscriptionAllocation: Entity<int>
    {
        public int SubscriptionId { get; set; }
    }
}