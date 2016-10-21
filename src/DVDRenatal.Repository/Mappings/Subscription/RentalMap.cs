using System.Data.Entity.ModelConfiguration;
using DVDRental.Subscription.RentalHistory;

namespace DVDRenatal.Repository.Mappings.Subscription
{
    public class RentalMap: EntityTypeConfiguration<Rental> {
        public RentalMap() {
            ToTable("Rentals").HasKey(c => c.Id);


            Property(c => c.SubscriptionId).HasColumnName("SubscriptionId");
            Property(c => c.DvdId).HasColumnName("DvdId");
            Property(c => c.DateSentOut).HasColumnName("DateSentOut");
            Property(c => c.DateReturned).HasColumnName("DateReturned").IsOptional();
        }
    }
}