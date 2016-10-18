using System.Data.Entity;
using Autofac;
using DVDRenatal.Infrastructure.Repository;
using DVDRenatal.Repository;
using DVDRental.Operational.ApplicationService;

namespace DVDRental.Operational.UI
{
    public class OperationalModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OperationService>().As<OperationService>().InstancePerRequest();

            builder.RegisterType<DVDRentalContext>()
                .As<DbContext>()
                .WithParameter("connectionString", "ApplicationServices").InstancePerRequest();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
        }
    }
}