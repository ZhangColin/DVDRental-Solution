using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Fulfillment.Contracts.Events
{
    /// <summary>
    /// 电影已归还
    /// </summary>
    public class FilmReturned: IMessage
    {
        public int FilmId { get; set; }
        public int Subscription { get; set; }
    }
}