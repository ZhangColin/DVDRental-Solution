namespace DVDRental.Subscription.RentalRequests.Events
{
    /// <summary>
    /// 移除租借请求
    /// </summary>
    public class RentalRequestRemoved
    {
        public int FilmId { get; set; }
        public int MemberId { get; set; }
    }
}