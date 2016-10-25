using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Domain;
using DVDRenatal.Infrastructure.Messages;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;
using DVDRental.Fulfillment.Contracts.Commands;
using DVDRental.Fulfillment.Contracts.Events;
using DVDRental.Fulfillment.Fulfilment;
using DVDRental.Fulfillment.Fulfilment.Events;

namespace DVDRental.Fulfillment.ApplicationService.Handlers
{
    /// <summary>
    /// 选择分配租借请求
    /// </summary>
    public class AssignRentalAllocationsToPickerHandler: ICommandHandler<AssignRentalAllocationsToPicker>
    {
        private readonly IFulfilmentRepository _fulfilmentRequestRepository;
        private readonly IMessageBus _messageBus;

        public AssignRentalAllocationsToPickerHandler(IFulfilmentRepository fulfilmentRequestRepository, IMessageBus messageBus)
        {
            _fulfilmentRequestRepository = fulfilmentRequestRepository;
            _messageBus = messageBus;
        }

        public void Execute(AssignRentalAllocationsToPicker command)
        {
            IEnumerable<FulfilmentRequest> requestsToAssign = _fulfilmentRequestRepository.FindOldsetUnassignedTop(10).ToList();

            using (DomainEvents.Register((FulfilmentRequestAssignedForPicking s) => _messageBus.Send(new FilmBeingPicked() {
                FilmId = s.FilmId,
                SubscriptionId = s.SubscriptionId
            }))) {
                foreach (var request in requestsToAssign) {
                    request.AssignForPickingTo(command.PickerName);

                    _fulfilmentRequestRepository.Save(request);
                }
            }

        }
    }
}