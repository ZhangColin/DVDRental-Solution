using System.Threading.Tasks;

namespace DVDRenatal.Infrastructure.CommandProcessor
{
    public interface ICommandBus
    {
        Task Submit<TCommand>(TCommand command) where TCommand : ICommand;
    }
}