using System.Collections.Generic;
using DVDRental.Fulfillment.Stock;

namespace DVDRental.Operational.UI.Models
{
    public class StockModel
    {
        public int FilmId { get; set; }
        public IEnumerable<Dvd> Stock { get; set; }
    }
}