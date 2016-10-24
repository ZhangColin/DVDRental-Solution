using System;

namespace DVDRental.Fulfillment.Stock
{
    /// <summary>
    /// 当前借出情况
    /// </summary>
    public class CurrentLoan
    {
        /// <summary>
        /// 会员
        /// </summary>
        public int? SubscriptionId { get; private set; }
        /// <summary>
        /// 租借日期
        /// </summary>
        public DateTime? DateLoanedOut { get; private set; }

        private CurrentLoan()
        {
        }

        public CurrentLoan(int? subscriptionId, DateTime? dateLoanedOut)
        {
            SubscriptionId = subscriptionId;
            DateLoanedOut = dateLoanedOut;
        }
    }
}