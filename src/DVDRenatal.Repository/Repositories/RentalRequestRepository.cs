using System;
using System.Data.Entity;
using System.Linq;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Subscription.RentalRequests;

namespace DVDRenatal.Repository.Repositories
{
    public class RentalRequestRepository: EfRepository<RentalRequest>, IRentalRequestRepository
    {
        public RentalRequestRepository(DbContext context) : base(context)
        {
        }

        public RentalRequestList FindBy(int subscriptionId)
        {
            RentalRequestList list = new RentalRequestList(subscriptionId);
            list.RentalRequests = this.Query(r => r.SubscriptionId == subscriptionId).ToList();
            return list;
        }

        public void Add(RentalRequestList request)
        {
            this.Add(request.RentalRequests);
        }
    }
}