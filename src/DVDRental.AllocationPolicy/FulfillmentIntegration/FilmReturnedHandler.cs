using DVDRenatal.Infrastructure.Messages;
using DVDRental.Fulfillment.Contracts.Events;

namespace DVDRental.AllocationPolicy.FulfillmentIntegration
{
    public class FilmReturnedHandler: IMessageHandler<FilmReturned>
    {
        public void Execute(FilmReturned message)
        {
            // Update rental history

            // start to allocate another
        }
    }
}