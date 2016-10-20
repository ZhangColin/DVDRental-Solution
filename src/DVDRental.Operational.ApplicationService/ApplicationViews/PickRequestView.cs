using System;
using System.Collections.Generic;

namespace DVDRental.Operational.ApplicationService.ApplicationViews
{
    public class PickRequestView
    {
        public string Id { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime Requested { get; set; }
        public List<int> DvdIdsToFulfil { get; set; }
        public string FilmTitle { get; set; }
        public string FulfilmentRequestId { get; set; }
    }
}