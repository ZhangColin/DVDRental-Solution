using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Fulfillment.Contracts.Events
{
    /// <summary>
    /// 电影已派送
    /// </summary>
    public class FilmDispatched: IMessage
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}