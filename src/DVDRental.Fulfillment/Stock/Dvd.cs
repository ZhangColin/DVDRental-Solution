using System;
using DVDRenatal.Infrastructure.Domain;
using DVDRental.Fulfillment.Stock.Events;

namespace DVDRental.Fulfillment.Stock
{
    /// <summary>
    /// Dvd
    /// </summary>
    public class Dvd: Entity<int>
    {
        /// <summary>
        /// 电影
        /// </summary>
        public int FilmId { get; private set; }
        /// <summary>
        /// 条形码
        /// </summary>
        public string Barcode { get; private set; }
        /// <summary>
        /// 当前租借情况
        /// </summary>
        public CurrentLoan CurrentLoan { get; private set; }

        private Dvd()
        {
        }

        public Dvd(int filmId, string barcode)
        {
            FilmId = filmId;
            Barcode = barcode;

            CurrentLoan = new CurrentLoan(null, null);

            DomainEvents.Raise(new DvdAdded() {FilmId = filmId});
        }

        /// <summary>
        /// 借出
        /// </summary>
        /// <param name="subscriptionId"></param>
        public void LoanTo(int subscriptionId)
        {
            CurrentLoan = new CurrentLoan(subscriptionId, DateTime.Now);

            // 需要从出租列表中删除
            // Needs to be removed from the rental list
            DomainEvents.Raise(new DvdLoanedOut()
            {
                FilmId = FilmId,
                SubscriptionId = subscriptionId
            });
        }

        /// <summary>
        /// 归还
        /// </summary>
        public void ReturnLoan()
        {
            if (CurrentLoan.SubscriptionId!=null)
            {
                // 需要从出租列表中删除
                // Needs to be removed from the rental list
                DomainEvents.Raise(new Events.DvdReturned()
                {
                    FilmId = FilmId,
                    Subscription = CurrentLoan.SubscriptionId.Value
                });

                CurrentLoan = new CurrentLoan(null, null);
            }
        }
    }
}