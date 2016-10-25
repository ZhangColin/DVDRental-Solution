using System.Collections.Generic;

namespace DVDRental.Operational.ApplicationService.ApplicationViews
{
    /// <summary>
    /// 选中请求列表视图
    /// </summary>
    public class PickListView
    {
        public List<PickRequestView> PickRequests { get; set; }
        public string AssignedTo { get; set; }
    }
}