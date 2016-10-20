using System.Data.Entity.ModelConfiguration;
using DVDRental.Fulfillment.Stock;

namespace DVDRenatal.Repository.Mappings.Fulfilment
{
    public class DvdMap: EntityTypeConfiguration<Dvd> {
        public DvdMap() {
            ToTable("Dvds").HasKey(c => c.Id);

            Property(c => c.FilmId).HasColumnName("FilmId");
            Property(c => c.Barcode).HasColumnName("Barcode");
            Property(c => c.CurrentLoan.SubscriptionId).HasColumnName("SubscriptionId");
            Property(c => c.CurrentLoan.DateLoanedOut).HasColumnName("DateLoanedOut");
        }
    }
}