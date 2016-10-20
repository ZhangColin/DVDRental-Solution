using System;
using DVDRenatal.Infrastructure.Domain;
using DVDRental.Fulfillment.Fulfilment.Events;

namespace DVDRental.Fulfillment.Fulfilment
{
    public class FulfilmentRequest: Entity<string>
    {
        public int FilmId { get; private set; }
        public int SubscriptionId { get; private set; }
        public DateTime Requested { get; private set; }
        public bool IsDispatched { get; private set; }
        public string AssignedTo { get; private set; }

        private FulfilmentRequest()
        {
        }

        public FulfilmentRequest(int filmId, int subscriptionId)
        {
            FilmId = filmId;
            SubscriptionId = subscriptionId;
            Requested = DateTime.Now;
            Id = String.Format("{0}-{1}", filmId, subscriptionId);
        }

        public bool IsAssigned()
        {
            return !string.IsNullOrEmpty(AssignedTo);
        }

        public void AssignForPickingTo(string picker)
        {
            if (!IsAssigned())
            {
                AssignedTo = picker;

                DomainEvents.Raise(new FulfilmentRequestAssignedForPicking()
                {
                    FilmId = FilmId,
                    SubscriptionId = SubscriptionId
                });
            }
        }

        public void FulfilledWith(int dveId)
        {
            if (!IsDispatched)
            {
                IsDispatched = true;

                DomainEvents.Raise(new FulfilmentRequestDispatched()
                {
                    FilmId = FilmId,
                    SubscriptionId = SubscriptionId,
                    DvdId = dveId
                });
            }
        }
    }
}