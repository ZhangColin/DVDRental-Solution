using System;

namespace DVDRental.Subscription.Subscriptions
{
    public class Package
    {
        public int DiscsOutAtSameTime { get; set; }
        public int NewReleasesAMonth { get; set; }
        public DateTime StartDate { get; set; }
        //public Money MonthlyCost { get; set; }

        public bool IsAllowedAHoliday()
        {
            return true;
        }

        public bool IsADowngradeFrom(Package package)
        {
            return false;
        }
    }
}