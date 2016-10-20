using System.Data.Entity;
using Autofac;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Messages;
using DVDRenatal.Infrastructure.Repository;
using DVDRenatal.Repository;
using DVDRenatal.Repository.Repositories;
using DVDRental.AllocationPolicy;
using DVDRental.AllocationPolicy.FulfillmentIntegration;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;
using DVDRental.Fulfillment.ApplicationService.Handlers;
using DVDRental.Fulfillment.Contracts;
using DVDRental.Fulfillment.Contracts.Commands;
using DVDRental.Fulfillment.Contracts.Events;
using DVDRental.Fulfillment.Fulfilment;
using DVDRental.FulfillmentPolicy;
using DVDRental.FulfillmentPolicy.SubscriptionIntegration;
using DVDRental.FulfillmentPolicy.WebEventForwarding;
using DVDRental.Operational.ApplicationService;
using DVDRental.Subscription.ApplicationService.Handlers;
using DVDRental.Subscription.Contracts.Events;
using DVDRental.Subscription.Contracts.InternalCommands;
using DVDRental.Subscription.RentalRequests;
using DVDRental.Subscription.ApplicationService.BusinessUseCases;
using FilmReturned = DVDRental.Fulfillment.Contracts.Events.FilmReturned;

namespace DVDRental.Operational.UI
{
    public class OperationalModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OperationService>().As<OperationService>().InstancePerRequest();

            builder.RegisterType<DVDRentalContext>()
                .As<DbContext>()
                .WithParameter("connectionString", "ApplicationServices").SingleInstance();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).SingleInstance();
            builder.RegisterType<FulfilmentRepository>().As<IFulfilmentRepository>().SingleInstance();
            builder.RegisterType<RentalRequestRepository>().As<IRentalRequestRepository>().SingleInstance();


            builder.RegisterType<AddFilmToCatalogueHandler>().As<ICommandHandler<AddFilmToCatalogue>>().SingleInstance();
            builder.RegisterType<AddStockHandler>().As<ICommandHandler<AddStock>>().SingleInstance();
            builder.RegisterType<AssignRentalAllocationsToPickerHandler>().As<ICommandHandler<AssignRentalAllocationsToPicker>>().SingleInstance();
            builder.RegisterType<MarkRentalAllocationAsDispatchedHandler>().As<ICommandHandler<MarkRentalAllocationAsDispatched>>().SingleInstance();
            builder.RegisterType<ReturnFilmHandler>().As<ICommandHandler<ReturnAFilm>>().SingleInstance();
            builder.RegisterType<RegisterHandler>().As<ICommandHandler<Register>>().SingleInstance();
            builder.RegisterType<CustomerWantsToRentAFilmHandler>().As<ICommandHandler<CustomerWantsToRentAFilm>>().SingleInstance();
            builder.RegisterType<CustomerIsNotInterestedInRentingThisFilmHandler>().As<ICommandHandler<CustomerIsNotInterestedInRentingThisFilm>>().SingleInstance();

            builder.RegisterType<FilmBeingPickedHandler>().As<IMessageHandler<FilmBeingPicked>>().SingleInstance();
            builder.RegisterType<FilmDispatchedHandler>().As<IMessageHandler<FilmDispatched>>().SingleInstance();
            builder.RegisterType<FilmReturnedHandler>().As<IMessageHandler<FilmReturned>>().SingleInstance();
            builder.RegisterType<StockAddedHandler>().As<IMessageHandler<ACopyOfAFilmHasBeenAddedToTheStock>>().SingleInstance();
            builder.RegisterType<AddRentalHistoryHandler>().As<IMessageHandler<AddRentalHistory>>().SingleInstance();
            builder.RegisterType<AllocateRentalRequestHandler>().As<IMessageHandler<AllocateRentalRequest>>().SingleInstance();
            builder.RegisterType<PublishThatACopyOfAFilmHasBeenAddedToTheStockHandler>().As<IMessageHandler<PublishThatACopyOfAFilmHasBeenAddedToTheStock>>().SingleInstance();
            builder.RegisterType<PublishThatAFilmHasBeenDispatchedHandler>().As<IMessageHandler<PublishThatAFilmHasBeenDispatched>>().SingleInstance();
            builder.RegisterType<PublishThatTheFilmIsBeingPickedHandler>().As<IMessageHandler<PublishThatTheFilmIsBeingPicked>>().SingleInstance();
            builder.RegisterType<FilmHasBeenAllocatedHandler>().As<IMessageHandler<FilmHasBeenAllocated>>().SingleInstance();
            builder.RegisterType<AssignDvdToSubscriptionHandler>().As<IMessageHandler<AssignDvdToSubscription>>().SingleInstance();
        }
    }
}