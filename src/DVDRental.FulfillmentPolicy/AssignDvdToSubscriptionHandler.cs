using DVDRenatal.Infrastructure.Messages;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Fulfillment.Contracts;
using DVDRental.Fulfillment.Stock;

namespace DVDRental.FulfillmentPolicy
{
    public class AssignDvdToSubscriptionHandler: IMessageHandler<AssignDvdToSubscription>
    {
        private readonly IRepository<Dvd> _dvdRepository;

        public AssignDvdToSubscriptionHandler(IRepository<Dvd> dvdRepository)
        {
            _dvdRepository = dvdRepository;
        }

        public void Execute(AssignDvdToSubscription message)
        {
            var dvd = _dvdRepository.Get(message.DvdId);
            dvd.LoanTo(message.SubscriptionId);

            _dvdRepository.Save(dvd);
        }
    }
}