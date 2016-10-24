using System;
using System.Collections.Generic;
using DVDRenatal.Infrastructure.Domain;

namespace DVDRental.Subscription.Subscriptions
{
    /// <summary>
    /// 会员（订阅者）
    /// </summary>
    public class Subscription: Entity<int>
    {
        /// <summary>
        /// 套餐
        /// </summary>
        public Package Package { get; set; }
        public int PaymentHolidays { get; set; }
        /// <summary>
        /// 邮件地址
        /// </summary>
        public string EmailAddress { get; set; }

        private Subscription()
        {
        }

        public Subscription(Package package)
        {
            Package = package;
        }

        /// <summary>
        /// 假期支付
        /// </summary>
        /// <param name="endDate"></param>
        /// <param name="rentals"></param>
        public void StartPaymentHoliday(DateTime endDate, CurrentPeriodRentals rentals) { }

        /// <summary>
        /// 取消当前租借周期
        /// </summary>
        /// <param name="rentals"></param>
        public void Cancel(CurrentPeriodRentals rentals) { }

        /// <summary>
        /// 更改套餐
        /// </summary>
        /// <param name="package"></param>
        /// <param name="rentals"></param>
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

        /// <summary>
        /// 是否有资格租借一部电影
        /// </summary>
        /// <param name="currentPeriodRentals"></param>
        /// <param name="currentFulfilmentRequests"></param>
        /// <returns></returns>
        public bool IsEligibleToRecieveAFilm(CurrentPeriodRentals currentPeriodRentals,
            IEnumerable<Allocation.Allocation> currentFulfilmentRequests)
        {
            return true;
        }
    }
}