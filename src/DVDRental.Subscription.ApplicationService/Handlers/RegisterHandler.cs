using System;
using System.Threading.Tasks;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.Repository;
using DVDRental.Subscription.ApplicationService.BusinessUseCases;
using DVDRental.Subscription.Subscriptions;

namespace DVDRental.Subscription.ApplicationService.Handlers
{
    public class RegisterHandler: ICommandHandler<Register>
    {
        private readonly IRepository<Subscriptions.Subscription> _subscriptionRepository;

        public RegisterHandler(IRepository<Subscriptions.Subscription> subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public void Execute(Register command)
        {
            var package = new Package();
            package.DiscsOutAtSameTime = 1;
            package.StartDate = DateTime.Now;

            var subscription = new Subscriptions.Subscription(package);
            subscription.EmailAddress = command.EmailAddress;

            _subscriptionRepository.Add(subscription);
        }
    }
}