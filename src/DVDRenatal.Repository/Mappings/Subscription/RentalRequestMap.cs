using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DVDRental.Subscription.Allocation;
using DVDRental.Subscription.RentalRequests;

namespace DVDRenatal.Repository.Mappings.Subscription
{
    public class RentalRequestMap: EntityTypeConfiguration<RentalRequest> {
        public RentalRequestMap() {
            ToTable("RentalRequests").HasKey(c => c.Id);


            Property(c => c.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(c => c.SubscriptionId).HasColumnName("SubscriptionId");
            Property(c => c.FilmId).HasColumnName("FilmId");
            Property(c => c.Requested).HasColumnName("Requested");
            Property(c => c.IsBeingPick).HasColumnName("IsBeingPick");
        }
    }
}