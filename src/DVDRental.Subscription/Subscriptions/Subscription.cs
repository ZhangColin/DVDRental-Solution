using System;
using System.Collections.Generic;
using DVDRenatal.Infrastructure.Domain;

namespace DVDRental.Subscription.Subscriptions
{
    public class Subscription: Entity<int>
    {
        public Package Package { get; set; }
        public int PaymentHolidays { get; set; }
        public string EmailAddress { get; set; }

        public Subscription(Package package)
        {
            Package = package;
        }

        public void StartPaymentHoliday(DateTime endDate, CurrentPeriodRentals rentals) { }

        public void Cancel(CurrentPeriodRentals rentals) { }

        public void ChangePackage(Package package, CurrentPeriodRentals rentals)
        {
            if (package.IsADowngradeFrom(this.Package))
            {
                
            }
            else
            {
                this.Package = package;
            }
        }

        public bool IsEligibleToRecieveAFilm(CurrentPeriodRentals currentPeriodRentals,
            IEnumerable<Allocation.Allocation> currentFulfilmentRequests)
        {
            return true;
        }
    }
}