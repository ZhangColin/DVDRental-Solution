using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Fulfillment.Fulfilment;

namespace DVDRenatal.Repository.Repositories
{
    public class FulfilmentRepository: EfRepository<FulfilmentRequest>, IFulfilmentRepository
    {

        public FulfilmentRepository(DbContext context) : base(context) {
        }

        public FulfilmentRequest FindBy(int filmId, int subscriptionId)
        {
            return this.Get(fulfilmentRequest =>
                    fulfilmentRequest.FilmId == filmId && fulfilmentRequest.SubscriptionId == subscriptionId);
        }

        public IEnumerable<FulfilmentRequest> FindAllAssignedTo(string pickerName)
        {
            return this.Query(fulfilmentRequest => fulfilmentRequest.AssignedTo == pickerName);
        }

        public IEnumerable<FulfilmentRequest> FindOldsetUnassignedTop(int number)
        {
            return All().Take(number).AsEnumerable();
        }
    }
}