using System.Data.Entity.ModelConfiguration;
using DVDRental.Catalogue.Catalogue;

namespace DVDRenatal.Repository.Mappings.Catalogue
{
    public class FilmMap: EntityTypeConfiguration<Film> {
        public FilmMap() {
            ToTable("Films").HasKey(c => c.Id);

            Property(c => c.Title).HasColumnName("Title");
            Property(c => c.ReleaseDate).HasColumnName("ReleaseDate");
            Property(c => c.Certification).HasColumnName("Certification");
        }
    }
}