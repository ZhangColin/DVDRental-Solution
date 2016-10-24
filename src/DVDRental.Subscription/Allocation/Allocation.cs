using System.Collections.Generic;
using System.Linq;
using DVDRenatal.Infrastructure.Domain;
using DVDRental.Subscription.Allocation.Events;

namespace DVDRental.Subscription.Allocation
{
    /// <summary>
    /// 分配（一部电影对应一个分配）
    /// </summary>
    public class Allocation: Entity<int>
    {
        /// <summary>
        /// 库存数
        /// </summary>
        public int Stock { get; private set; }
        /// <summary>
        /// 有效数
        /// </summary>
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

        /// <summary>
        /// 增加库存
        /// </summary>
        public void IncreaseStock()
        {
            Stock++;
        }

        /// <summary>
        /// 分配一部电影给会员
        /// </summary>
        /// <param name="subscriptionId"></param>
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

        /// <summary>
        /// 是否已经分配过该会员
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
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