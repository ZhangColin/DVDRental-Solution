using System;

namespace DVDRental.Subscription.Subscriptions
{
    /// <summary>
    /// 套餐
    /// </summary>
    public class Package
    {
        /// <summary>
        /// 同一时间租借的Dvd数
        /// </summary>
        public int DiscsOutAtSameTime { get; set; }
        /// <summary>
        /// 一个月允许租借的新片
        /// </summary>
        public int NewReleasesAMonth { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartDate { get; set; }
        //public Money MonthlyCost { get; set; }

        /// <summary>
        /// 是否允许假期延期
        /// </summary>
        /// <returns></returns>
        public bool IsAllowedAHoliday()
        {
            return true;
        }

        /// <summary>
        /// 是否降级
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public bool IsADowngradeFrom(Package package)
        {
            return false;
        }
    }
}