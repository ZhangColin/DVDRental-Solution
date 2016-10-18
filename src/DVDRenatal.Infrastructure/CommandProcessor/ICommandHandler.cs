using System.Threading.Tasks;

namespace DVDRenatal.Infrastructure.CommandProcessor
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand {
        Task Execute(TCommand command);
    }
}