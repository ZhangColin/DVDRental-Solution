using System;
using DVDRenatal.Infrastructure.Domain;

namespace DVDRental.Subscription.RentalRequests
{
    public class RentalRequest: Entity<string>
    {
        public int FilmId { get; private set; }
        public int SubscriptionId { get; private set; }

        public DateTime Requested { get; private set; }
        public bool IsBeingPick { get; private set; }

        private RentalRequest()
        {
        }

        public RentalRequest(int filmId, int subscriptionId)
        {
            Id = Guid.NewGuid().ToString();
            FilmId = filmId;
            SubscriptionId = subscriptionId;
            Requested = DateTime.Now;
            IsBeingPick = false;
        }

        public void IsBeingPickedForDispatch()
        {
            IsBeingPick = true;
        }

        public bool CanBeRemovedFromList
        {
            get { return !IsBeingPick; }
        }
    }
}