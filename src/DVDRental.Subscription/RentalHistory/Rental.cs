using System;
using DVDRenatal.Infrastructure.Domain;

namespace DVDRental.Subscription.RentalHistory
{
    /// <summary>
    /// 租借历史
    /// </summary>
    public class Rental: Entity<int>
    {
        /// <summary>
        /// Dvd
        /// </summary>
        public int DvdId { get; private set; }
        /// <summary>
        /// 会员
        /// </summary>
        public int SubscriptionId { get; private set; }
        /// <summary>
        /// 借出日期
        /// </summary>
        public DateTime DateSentOut { get; private set; }
        /// <summary>
        /// 归还日期
        /// </summary>
        public DateTime? DateReturned { get; private set; }

        private Rental()
        {
        }

        public Rental(int dvdId, int subscriptionId, DateTime sentOut)
        {
            DvdId = dvdId;
            SubscriptionId = subscriptionId;
            DateSentOut = sentOut;
        }
    }
}