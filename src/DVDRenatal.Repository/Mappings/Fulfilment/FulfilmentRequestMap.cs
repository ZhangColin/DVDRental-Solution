using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DVDRental.Fulfillment.Fulfilment;

namespace DVDRenatal.Repository.Mappings.Fulfilment
{
    public class FulfilmentRequestMap: EntityTypeConfiguration<FulfilmentRequest> {
        public FulfilmentRequestMap() {
            ToTable("FulfilmentRequests").HasKey(c => c.Id);

            Property(f => f.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(c => c.SubscriptionId).HasColumnName("SubscriptionId");
            Property(c => c.FilmId).HasColumnName("FilmId");
            Property(c => c.Requested).HasColumnName("Requested");
            Property(c => c.IsDispatched).HasColumnName("IsDispatched");
            Property(c => c.AssignedTo).HasColumnName("AssignedTo");
        }
    }
}