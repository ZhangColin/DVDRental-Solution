using System;
using DVDRenatal.Infrastructure.Domain;
using DVDRental.Fulfillment.Stock.Events;

namespace DVDRental.Fulfillment.Stock
{
    public class Dvd: Entity<int>
    {
        public int FilmId { get; private set; }
        public string Barcode { get; private set; }
        public CurrentLoan CurrentLoan { get; private set; }

        private Dvd()
        {
        }

        public Dvd(int filmId, string barcode)
        {
            FilmId = filmId;
            Barcode = barcode;

            DomainEvents.Raise(new DvdAdded() {FilmId = filmId});
        }

        public void LoanTo(int subscriptionId)
        {
            CurrentLoan = new CurrentLoan(subscriptionId, DateTime.Now);

            // Needs to be removed from the rental list
            DomainEvents.Raise(new FilmLoanedOut()
            {
                FilmId = FilmId,
                SubscriptionId = subscriptionId
            });
        }

        public void ReturnLoan()
        {
            if (CurrentLoan!=null)
            {
                // Needs to be removed from the rental list
                DomainEvents.Raise(new FilmReturned()
                {
                    FilmId = FilmId,
                    Subscription = CurrentLoan.SubscriptionId
                });

                CurrentLoan = null;
            }
        }
    }
}