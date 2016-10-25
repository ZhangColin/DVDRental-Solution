using System;
using DVDRenatal.Infrastructure.Messages;
using DVDRental.Fulfillment.Contracts.Events;
using DVDRental.Subscription.RentalRequests;

namespace DVDRental.AllocationPolicy.FulfillmentIntegration
{
    /// <summary>
    /// 租借电影的请求被选中
    /// </summary>
    public class FilmBeingPickedHandler: IMessageHandler<FilmBeingPicked> {
        private readonly IRentalRequestRepository _rentalRequestRepository;

        public FilmBeingPickedHandler(IRentalRequestRepository rentalRequestRepository)
        {
            _rentalRequestRepository = rentalRequestRepository;
        }

        public void Execute(FilmBeingPicked message)
        {
            RentalRequestList requestList = _rentalRequestRepository.FindBy(message.SubscriptionId);
            requestList.MarkAsReadyForDispatch(message.FilmId);

            _rentalRequestRepository.Save(requestList);
        }
    }
}