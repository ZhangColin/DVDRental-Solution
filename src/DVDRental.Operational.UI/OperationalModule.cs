using System.Data.Entity;
using Autofac;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Repository;
using DVDRenatal.Repository;
using DVDRenatal.Repository.Repositories;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;
using DVDRental.Fulfillment.ApplicationService.Handlers;
using DVDRental.Fulfillment.Fulfilment;
using DVDRental.Operational.ApplicationService;
using DVDRental.Subscription.RentalRequests;

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
            builder.RegisterType<FulfilmentRepository>().As<IFulfilmentRepository>();
            builder.RegisterType<RentalRequestRepository>().As<IRentalRequestRepository>();


            builder.RegisterType<AddFilmToCatalogueHandler>().As<ICommandHandler<AddFilmToCatalogue>>();
        }
    }
}