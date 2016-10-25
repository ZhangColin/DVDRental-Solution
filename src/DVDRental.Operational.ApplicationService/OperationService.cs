using System;
using System.Collections.Generic;
using System.Linq;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Catalogue.Catalogue;
using DVDRental.Fulfillment.Fulfilment;
using DVDRental.Fulfillment.Stock;
using DVDRental.Operational.ApplicationService.ApplicationViews;

namespace DVDRental.Operational.ApplicationService
{
    /// <summary>
    /// 后台操作服务
    /// </summary>
    public class OperationService
    {
        private readonly IRepository<Film> _filmRepository;
        private readonly IFulfilmentRepository _fulfilmentRepository;
        private readonly IRepository<Dvd> _dvdRepository;

        public OperationService(IRepository<Film> filmRepository, IFulfilmentRepository fulfilmentRepository, IRepository<Dvd> dvdRepository)
        {
            _filmRepository = filmRepository;
            _fulfilmentRepository = fulfilmentRepository;
            _dvdRepository = dvdRepository;
        }

        /// <summary>
        /// 显示电影列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Film> ViewAllFilms()
        {
            // Take 10
            return _filmRepository.Query(film => true).AsEnumerable();
        }

        /// <summary>
        /// 操作员想查看分配的租借申请
        /// </summary>
        /// <param name="processorName"></param>
        /// <returns></returns>
        public PickListView OperatorWantsToViewAssignedRentalAllocations(string processorName)
        {
            var fulfilmentRequests = _fulfilmentRepository.Query(request=>request.AssignedTo == processorName && !request.IsDispatched).ToList();

            var pickListView = new PickListView();
            pickListView.PickRequests = new List<PickRequestView>();
            pickListView.AssignedTo = processorName;

            foreach (var request in fulfilmentRequests)
            {
                var filmId = request.FilmId;

                PickRequestView pickRequestView = new PickRequestView();
                pickRequestView.FilmTitle = _filmRepository.Get(filmId).Title;
                pickRequestView.DvdIdsToFulfil = new List<int>();
                pickRequestView.FulfilmentRequestId = request.Id;
                pickRequestView.Requested = request.Requested;

                foreach (var dvd in _dvdRepository.Query(d=>d.CurrentLoan.SubscriptionId==null && d.FilmId==filmId))
                {
                    pickRequestView.DvdIdsToFulfil.Add(dvd.Id);
                }

                pickListView.PickRequests.Add(pickRequestView);
            }

            return pickListView;
        }

        /// <summary>
        /// 查看所有需要归还的Dvd
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Dvd> ViewAllPotentialReturns()
        {
            return _dvdRepository.Query(x => x.CurrentLoan.SubscriptionId!=null).AsEnumerable();
        }

        /// <summary>
        /// 查看电影库存
        /// </summary>
        /// <param name="filmId"></param>
        /// <returns></returns>
        public IEnumerable<Dvd> ViewStockFor(int filmId)
        {
            return _dvdRepository.Query(x => x.FilmId == filmId).AsEnumerable();
        }
    }
}