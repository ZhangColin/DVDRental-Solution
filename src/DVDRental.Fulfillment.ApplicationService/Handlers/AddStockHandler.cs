using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Domain;
using DVDRenatal.Infrastructure.Messages;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;
using DVDRental.Fulfillment.Contracts.Commands;
using DVDRental.Fulfillment.Stock;
using DVDRental.Fulfillment.Stock.Events;

namespace DVDRental.Fulfillment.ApplicationService.Handlers
{
    public class AddStockHandler: ICommandHandler<AddStock>
    {
        private readonly IRepository<Dvd> _dvdRepository;
        private readonly IMessageBus _messageBus;

        public AddStockHandler(IRepository<Dvd> dvdRepository, IMessageBus messageBus)
        {
            _dvdRepository = dvdRepository;
            _messageBus = messageBus;
        }

        public void Execute(AddStock command)
        {
            using (DomainEvents.Register((DvdAdded s)=>_messageBus.Send(new PublishThatACopyOfAFilmHasBeenAddedToTheStock() {FilmId = s.FilmId})))
            {
                var dvd = new Dvd(command.FilmId, command.Barcode);
                _dvdRepository.Add(dvd);
            }
            
        }
    }
}