using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using DVDRenatal.Infrastructure.Extensions;
using DVDRenatal.Infrastructure.Repository;

namespace DVDRenatal.Repository
{
    public class DVDRentalContext : EntitiesContext<DVDRentalContext>
    {
        public DVDRentalContext(string connectionString)
            : base(connectionString)
        {
            Configuration.AutoDetectChangesEnabled = true;
            //            Configuration.LazyLoadingEnabled = true;
                        Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            IEnumerable<Type> typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified && e.Entity is IOrphanable);
            var entries = ChangeTracker.Entries().Where(e => e.Entity is IOrphanable);
            entries.ForEach(entry =>
            {
                var orphanable = entry.Entity as IOrphanable;
                if (orphanable.IsOrphan())
                {
                    entry.State = EntityState.Deleted;
                }
            });
            return base.SaveChanges();
        }
    }
}