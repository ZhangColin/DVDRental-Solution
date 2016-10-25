using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Fulfillment.Contracts.Events
{
    /// <summary>
    /// 租借电影的请求被选中
    /// </summary>
    public class FilmBeingPicked : IMessage
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
    }
}