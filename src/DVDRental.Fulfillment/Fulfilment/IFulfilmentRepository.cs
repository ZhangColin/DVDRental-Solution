using System.Collections.Generic;
using DVDRenatal.Infrastructure.Repository;

namespace DVDRental.Fulfillment.Fulfilment
{
    public interface IFulfilmentRepository: IRepository<FulfilmentRequest>
    {
        FulfilmentRequest FindBy(int filmId, int subscriptionId);
        IEnumerable<FulfilmentRequest> FindAllAssignedTo(string pickerName);
        IEnumerable<FulfilmentRequest> FindOldsetUnassignedTop(int number);
    }
}