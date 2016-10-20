using System.Collections.Generic;
using System.Linq;
using DVDRenatal.Infrastructure.Domain;
using DVDRental.Subscription.RentalRequests.Events;

namespace DVDRental.Subscription.RentalRequests
{
    public class RentalRequestList
    {
        public int Id { get; set; }
        public IList<RentalRequest> RentalRequests { get; set; }

        public RentalRequestList(int subscriptionId)
        {
            Id = subscriptionId;
            RentalRequests = new List<RentalRequest>();
        }

        public void CreateRequestFor(int filmId)
        {
            if (!IsContainedInTheList(filmId))
            {
                var request = new RentalRequest(filmId, Id);
                RentalRequests.Add(request);

                DomainEvents.Raise(new FilmRequested()
                {
                    FilmId = filmId,
                    SubscriptionId = Id,
                    Id = request.Id
                });
            }
        }

        public void RemoveFromTheList(int filmId)
        {
            if (!IsContainedInTheList(filmId))
            {
                RentalRequest request = RentalRequests.SingleOrDefault(x => x.FilmId == filmId);
                RentalRequests.Remove(request);
                DomainEvents.Raise(new RentalRequestRemoved
                {
                    FilmId = filmId,
                    MemberId = Id
                });
            }
        }

        private bool IsContainedInTheList(int filmId)
        {
            return RentalRequests.Count(x => x.FilmId == filmId) > 0;
        }

        public void MarkAsReadyForDispatch(int filmId)
        {
            if (IsContainedInTheList(filmId))
            {
                RentalRequests.SingleOrDefault(x=>x.FilmId==filmId).IsBeingPickedForDispatch();
            }
        }

        public void Fulfilled(int filmId)
        {
            RentalRequest request = RentalRequests.SingleOrDefault(x => x.FilmId == filmId);
            RentalRequests.Remove(request);

            DomainEvents.Raise(new RequestFulfilled
            {
                FilmId = filmId,
                SubscriptionId = Id
            });
        }
    }
}