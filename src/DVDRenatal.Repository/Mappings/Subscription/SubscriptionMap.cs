using System.Data.Entity.ModelConfiguration;
using DVDRental.Subscription.Allocation;

namespace DVDRenatal.Repository.Mappings.Subscription
{
    public class SubscriptionMap: EntityTypeConfiguration<DVDRental.Subscription.Subscriptions.Subscription> {
        public SubscriptionMap() {
            ToTable("Subscriptions").HasKey(c => c.Id);


            Property(c => c.PaymentHolidays).HasColumnName("PaymentHolidays");
            Property(c => c.EmailAddress).HasColumnName("EmailAddress");
            Property(c => c.Package.DiscsOutAtSameTime).HasColumnName("DiscsOutAtSameTime");
            Property(c => c.Package.NewReleasesAMonth).HasColumnName("NewReleasesAMonth");
            Property(c => c.Package.StartDate).HasColumnName("StartDate");
            //Ignore(c => c.Package.MonthlyCost);
        }
    }
}