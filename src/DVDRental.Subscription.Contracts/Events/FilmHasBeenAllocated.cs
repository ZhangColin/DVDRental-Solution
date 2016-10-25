using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Subscription.Contracts.Events
{
    /// <summary>
    /// 电影已经分配
    /// </summary>
    public class FilmHasBeenAllocated: IMessage
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}