using System;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Domain;
using DVDRenatal.Infrastructure.Messages;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Fulfillment.ApplicationService.BusinessUseCases;
using DVDRental.Fulfillment.Contracts.Events;
using DVDRental.Fulfillment.Stock;
using DVDRental.Fulfillment.Stock.Events;

namespace DVDRental.Fulfillment.ApplicationService.Handlers
{
    /// <summary>
    /// 归还一部电影
    /// </summary>
    public class ReturnFilmHandler: ICommandHandler<ReturnAFilm>
    {
        private readonly IRepository<Dvd> _dvdRepository;
        private readonly IMessageBus _messageBus;

        public ReturnFilmHandler(IRepository<Dvd> dvdRepository, IMessageBus messageBus)
        {
            _dvdRepository = dvdRepository;
            _messageBus = messageBus;
        }

        public void Execute(ReturnAFilm command)
        {
            using (DomainEvents.Register((DvdReturned s)=>_messageBus.Send(new FilmReturned()
            {
                FilmId = s.FilmId,
                Subscription = s.Subscription
            })))
            {
                var dvd = _dvdRepository.Get(command.DvdId);

                dvd.ReturnLoan();

                _dvdRepository.Save(dvd);
            }
        }
    }
}