using DVDRenatal.Infrastructure.Messages;
using DVDRental.Fulfillment.Fulfilment;
using DVDRental.Subscription.Contracts.Events;

namespace DVDRental.FulfillmentPolicy.SubscriptionIntegration
{
    /// <summary>
    /// 电影已经分配
    /// </summary>
    public class FilmHasBeenAllocatedHandler: IMessageHandler<FilmHasBeenAllocated>
    {
        private readonly IFulfilmentRepository _fulfilmentRepository;

        public FilmHasBeenAllocatedHandler(IFulfilmentRepository fulfilmentRepository)
        {
            _fulfilmentRepository = fulfilmentRepository;
        }

        public void Execute(FilmHasBeenAllocated message)
        {
            var request = _fulfilmentRepository.FindBy(message.FilmId, message.SubscriptionId);
            if (request==null)
            {
                var fulfilmentRequest = new FulfilmentRequest(message.FilmId, message.SubscriptionId);
                _fulfilmentRepository.Add(fulfilmentRequest);
            }
        }
    }
}