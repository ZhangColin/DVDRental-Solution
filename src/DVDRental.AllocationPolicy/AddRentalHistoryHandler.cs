using DVDRenatal.Infrastructure.Messages;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Subscription.Contracts.InternalCommands;
using DVDRental.Subscription.RentalHistory;

namespace DVDRental.AllocationPolicy
{
    /// <summary>
    /// 添加租借历史
    /// </summary>
    public class AddRentalHistoryHandler: IMessageHandler<AddRentalHistory>
    {
        private readonly IRepository<Rental> _rentalRepository;

        public AddRentalHistoryHandler(IRepository<Rental> rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public void Execute(AddRentalHistory message)
        {
            var rental = new Rental(message.FilmId, message.SubscriptionId, message.SentOutDate);
            _rentalRepository.Add(rental);
        }
    }
}