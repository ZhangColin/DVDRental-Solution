namespace DVDRental.Subscription.Allocation.Events
{
    /// <summary>
    /// 分配电影给会员
    /// </summary>
    public class FilmAllocated
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}