using System.Collections.Generic;
using System.Linq;
using DVDRenatal.Infrastructure.Domain;
using DVDRental.Subscription.Allocation.Events;

namespace DVDRental.Subscription.Allocation
{
    public class Allocation: Entity<int>
    {
        public int Stock { get; private set; }
        public int Available { get; set; }
        public List<SubscriptionAllocation> SubscriptionAllocations { get; private set; }

        private Allocation()
        {
        }

        public Allocation(int filmId, int stock)
        {
            Id = filmId;
            Stock = stock;
            SubscriptionAllocations = new List<SubscriptionAllocation>();
        }

        public void IncreaseStock()
        {
            Stock++;
        }

        public void AllocateUnitTo(int subscriptionId)
        {
            if (!HasAllocatedFor(subscriptionId))
            {
                SubscriptionAllocations.Add(new SubscriptionAllocation() {SubscriptionId = subscriptionId});

                DomainEvents.Raise(new FilmAllocated()
                {
                    FilmId = Id,
                    SubscriptionId = subscriptionId
                });
            }
        }

        public bool HasAllocatedFor(int subscriptionId)
        {
            if (SubscriptionAllocations==null)
            {
                SubscriptionAllocations = new List<SubscriptionAllocation>();
            }
            return SubscriptionAllocations.Count(x => x.SubscriptionId == subscriptionId) > 0;
        }
    }
}