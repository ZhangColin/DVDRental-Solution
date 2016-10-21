using System;
using DVDRenatal.Infrastructure.Domain;

namespace DVDRental.Subscription.RentalHistory
{
    public class Rental: Entity<int>
    {
        public int DvdId { get; private set; }
        public int SubscriptionId { get; private set; }
        public DateTime DateSentOut { get; private set; }
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