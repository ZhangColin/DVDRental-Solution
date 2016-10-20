using System;
using DVDRenatal.Infrastructure.Messages;

namespace DVDRental.Subscription.Contracts.InternalCommands
{
    public class AddRentalHistory: IMessage
    {
        public int FilmId { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime SentOutDate { get; set; }
    }
}