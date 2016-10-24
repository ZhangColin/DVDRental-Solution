using System;
using DVDRenatal.Infrastructure.Domain;
using DVDRental.Fulfillment.Fulfilment.Events;

namespace DVDRental.Fulfillment.Fulfilment
{
    /// <summary>
    /// 租借请求
    /// </summary>
    public class FulfilmentRequest: Entity<string>
    {
        /// <summary>
        /// 电影
        /// </summary>
        public int FilmId { get; private set; }
        /// <summary>
        /// 会员
        /// </summary>
        public int SubscriptionId { get; private set; }
        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime Requested { get; private set; }
        /// <summary>
        /// 是否派送
        /// </summary>
        public bool IsDispatched { get; private set; }
        /// <summary>
        /// 分配人
        /// </summary>
        public string AssignedTo { get; private set; }

        private FulfilmentRequest()
        {
        }

        public FulfilmentRequest(int filmId, int subscriptionId)
        {
            FilmId = filmId;
            SubscriptionId = subscriptionId;
            Requested = DateTime.Now;
            Id = String.Format("{0}-{1}", filmId, subscriptionId);
        }

        /// <summary>
        /// 是否分配
        /// </summary>
        /// <returns></returns>
        public bool IsAssigned()
        {
            return !string.IsNullOrEmpty(AssignedTo);
        }

        /// <summary>
        /// 选择分配
        /// </summary>
        /// <param name="picker"></param>
        public void AssignForPickingTo(string picker)
        {
            if (!IsAssigned())
            {
                AssignedTo = picker;

                DomainEvents.Raise(new FulfilmentRequestAssignedForPicking()
                {
                    FilmId = FilmId,
                    SubscriptionId = SubscriptionId
                });
            }
        }

        /// <summary>
        /// 满足请求（派送Dvd）
        /// </summary>
        /// <param name="dvdId"></param>
        public void FulfilledWith(int dvdId)
        {
            if (!IsDispatched)
            {
                IsDispatched = true;

                DomainEvents.Raise(new FulfilmentRequestDispatched()
                {
                    FilmId = FilmId,
                    SubscriptionId = SubscriptionId,
                    DvdId = dvdId
                });
            }
        }
    }
}