using System;

namespace DVDRental.Fulfillment.Stock
{
    public class CurrentLoan
    {
        public int SubscriptionId { get; private set; }
        public DateTime DateLoanedOut { get; private set; }

        public CurrentLoan(int subscriptionId, DateTime dateLoanedOut)
        {
            SubscriptionId = subscriptionId;
            DateLoanedOut = dateLoanedOut;
        }
    }
}