using System.Collections.Generic;
using System.Linq;
using DVDRenatal.Infrastructure.Domain;
using DVDRental.Subscription.RentalRequests.Events;

namespace DVDRental.Subscription.RentalRequests
{
    /// <summary>
    /// 租借请求列表（一个会员一张列表）
    /// </summary>
    public class RentalRequestList
    {
        public int Id { get; set; }
        /// <summary>
        /// 租借请求列表
        /// </summary>
        public IList<RentalRequest> RentalRequests { get; set; }

        public RentalRequestList(int subscriptionId)
        {
            Id = subscriptionId;
            RentalRequests = new List<RentalRequest>();
        }

        /// <summary>
        /// 创建一部电影的租借请求
        /// </summary>
        /// <param name="filmId"></param>
        public void CreateRequestFor(int filmId)
        {
            if (!IsContainedInTheList(filmId))
            {
                var request = new RentalRequest(filmId, Id);
                RentalRequests.Add(request);

                DomainEvents.Raise(new FilmRequested()
                {
                    FilmId = filmId,
                    SubscriptionId = Id,
                    RequestId = request.Id
                });
            }
        }

        /// <summary>
        /// 从请求列表中移除
        /// </summary>
        /// <param name="filmId"></param>
        public void RemoveFromTheList(int filmId)
        {
            if (!IsContainedInTheList(filmId))
            {
                RentalRequest request = RentalRequests.SingleOrDefault(x => x.FilmId == filmId);
                RentalRequests.Remove(request);
                DomainEvents.Raise(new RentalRequestRemoved
                {
                    FilmId = filmId,
                    MemberId = Id
                });
            }
        }

        /// <summary>
        /// 是否已经在租借请求列表中
        /// </summary>
        /// <param name="filmId"></param>
        /// <returns></returns>
        private bool IsContainedInTheList(int filmId)
        {
            return RentalRequests.Count(x => x.FilmId == filmId) > 0;
        }

        /// <summary>
        /// 标记一部电影已经准备派送
        /// </summary>
        /// <param name="filmId"></param>
        public void MarkAsReadyForDispatch(int filmId)
        {
            if (IsContainedInTheList(filmId))
            {
                RentalRequests.SingleOrDefault(x=>x.FilmId==filmId).IsBeingPickedForDispatch();
            }
        }

        /// <summary>
        /// 已满足会员对一部电影的租借请求
        /// </summary>
        /// <param name="filmId"></param>
        public void Fulfilled(int filmId)
        {
            RentalRequest request = RentalRequests.SingleOrDefault(x => x.FilmId == filmId);
            RentalRequests.Remove(request);

            DomainEvents.Raise(new RequestFulfilled
            {
                FilmId = filmId,
                SubscriptionId = Id
            });
        }
    }
}