using System.Collections.Generic;

namespace DVDRental.Operational.ApplicationService.ApplicationViews
{
    public class PickListView
    {
        public List<PickRequestView> PickRequests { get; set; }
        public string AssignedTo { get; set; }
    }
}