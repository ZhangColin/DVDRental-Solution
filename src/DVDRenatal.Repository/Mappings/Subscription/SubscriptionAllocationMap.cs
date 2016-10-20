using System.Data.Entity.ModelConfiguration;
using DVDRental.Subscription.Allocation;

namespace DVDRenatal.Repository.Mappings.Subscription
{
    public class SubscriptionAllocationMap: EntityTypeConfiguration<SubscriptionAllocation> {
        public SubscriptionAllocationMap() {
            ToTable("SubscriptionAllocations").HasKey(c => c.Id);


            Property(c => c.SubscriptionId).HasColumnName("SubscriptionId");
        }
    }
}