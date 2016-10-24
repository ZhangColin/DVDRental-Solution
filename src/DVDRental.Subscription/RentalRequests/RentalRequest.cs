using System;
using DVDRenatal.Infrastructure.Domain;

namespace DVDRental.Subscription.RentalRequests
{
    /// <summary>
    /// 租借请求
    /// </summary>
    public class RentalRequest: Entity<string>
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
        /// 是否已经被选中
        /// </summary>
        public bool IsBeingPick { get; private set; }

        private RentalRequest()
        {
        }

        public RentalRequest(int filmId, int subscriptionId)
        {
            Id = Guid.NewGuid().ToString();
            FilmId = filmId;
            SubscriptionId = subscriptionId;
            Requested = DateTime.Now;
            IsBeingPick = false;
        }

        /// <summary>
        /// 是否已经被选中
        /// </summary>
        public void IsBeingPickedForDispatch()
        {
            IsBeingPick = true;
        }

        /// <summary>
        /// 是否允许从列表中移除
        /// </summary>
        public bool CanBeRemovedFromList
        {
            get { return !IsBeingPick; }
        }
    }
}