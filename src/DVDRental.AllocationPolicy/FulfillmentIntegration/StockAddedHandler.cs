using DVDRenatal.Infrastructure.Messages;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Fulfillment.Contracts.Events;
using DVDRental.Subscription.Allocation;

namespace DVDRental.AllocationPolicy.FulfillmentIntegration
{
    /// <summary>
    /// 一部电影添加到库存
    /// </summary>
    public class StockAddedHandler: IMessageHandler<ACopyOfAFilmHasBeenAddedToTheStock>
    {
        private readonly IRepository<Allocation> _allocationRepository;

        public StockAddedHandler(IRepository<Allocation> allocationRepository)
        {
            _allocationRepository = allocationRepository;
        }

        public void Execute(ACopyOfAFilmHasBeenAddedToTheStock message)
        {
            var filmAllocations = _allocationRepository.Get(message.FilmId);
            if (filmAllocations==null)
            {
                filmAllocations = new Allocation(message.FilmId, 1);
                _allocationRepository.Add(filmAllocations);
            }
            else
            {
                filmAllocations.IncreaseStock();
                _allocationRepository.Save(filmAllocations);
            }
        }
    }
}