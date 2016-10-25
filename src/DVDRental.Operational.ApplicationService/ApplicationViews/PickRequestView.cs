using System;
using System.Collections.Generic;

namespace DVDRental.Operational.ApplicationService.ApplicationViews
{
    /// <summary>
    /// 选中请求视图
    /// </summary>
    public class PickRequestView
    {
        public string Id { get; set; }
        /// <summary>
        /// 会员
        /// </summary>
        public int SubscriptionId { get; set; }
        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime Requested { get; set; }
        /// <summary>
        /// 能满足请求的Dvd
        /// </summary>
        public List<int> DvdIdsToFulfil { get; set; }
        /// <summary>
        /// 电影标题
        /// </summary>
        public string FilmTitle { get; set; }
        public string FulfilmentRequestId { get; set; }
    }
}