using System.Data.Entity.ModelConfiguration;
using DVDRental.Subscription.Allocation;

namespace DVDRenatal.Repository.Mappings.Subscription
{
    public class AllocationMap: EntityTypeConfiguration<Allocation> {
        public AllocationMap() {
            ToTable("Allocations").HasKey(c => c.Id);

            Property(c => c.Stock).HasColumnName("Stock");
            Property(c => c.Available).HasColumnName("Available");

            HasMany(p => p.SubscriptionAllocations).WithRequired().Map(foreignKeyConfig => foreignKeyConfig.MapKey("AllocationId")).WillCascadeOnDelete(true);
        }
    }
}