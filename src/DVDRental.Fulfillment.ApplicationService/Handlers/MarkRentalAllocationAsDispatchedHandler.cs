using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Domain;
using DVDRenatal.Infrastructure.Messages;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;
using DVDRental.Fulfillment.Contracts.Commands;
using DVDRental.Fulfillment.Contracts.Events;
using DVDRental.Fulfillment.Fulfilment;
using DVDRental.Fulfillment.Fulfilment.Events;
using DVDRental.Fulfillment.Stock;

namespace DVDRental.Fulfillment.ApplicationService.Handlers
{
    /// <summary>
    /// 通知电影租借请求已被选中
    /// </summary>
    public class MarkRentalAllocationAsDispatchedHandler: ICommandHandler<MarkRentalAllocationAsDispatched>
    {
        private readonly IFulfilmentRepository _fulfilmentRepository;
        private readonly IRepository<Dvd> _dvdRepository;
        private readonly IMessageBus _messageBus;

        public MarkRentalAllocationAsDispatchedHandler(IFulfilmentRepository fulfilmentRepository, IRepository<Dvd> dvdRepository, IMessageBus messageBus)
        {
            _fulfilmentRepository = fulfilmentRepository;
            _dvdRepository = dvdRepository;
            _messageBus = messageBus;
        }

        public void Execute(MarkRentalAllocationAsDispatched command)
        {
            var request = _fulfilmentRepository.Get(command.FulfilmentRequestId);
            var dvd = _dvdRepository.Get(command.DvdId);
            using (DomainEvents.Register((FulfilmentRequestDispatched s) =>
            {
                _messageBus.Send(new FilmDispatched() {FilmId=s.FilmId, SubscriptionId = s.SubscriptionId});
                _messageBus.Send(new AssignDvdToSubscription() {DvdId=s.DvdId, SubscriptionId = s.SubscriptionId});
            }))
            {
                request.FulfilledWith(dvd.Id);

                _fulfilmentRepository.Save(request);
            }
        }
    }
}