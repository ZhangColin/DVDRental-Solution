using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Fulfillment.Contracts.Events
{
    /// <summary>
    /// 一部电影添加到库存
    /// </summary>
    public class ACopyOfAFilmHasBeenAddedToTheStock: IMessage
    {
        public  int FilmId { get; set; }
    }
}