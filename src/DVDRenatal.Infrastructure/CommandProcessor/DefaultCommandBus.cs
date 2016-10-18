using System;
using System.Threading.Tasks;
using DVDRenatal.Infrastructure.IoC;

namespace DVDRenatal.Infrastructure.CommandProcessor
{
    public class DefaultCommandBus: ICommandBus {
        public async Task Submit<TCommand>(TCommand command) where TCommand : ICommand {
            var handler = ServiceLocator.GetService<ICommandHandler<TCommand>>();
            if (handler == null) {
                throw new Exception(string.Format("未找到命令处理器：{0}。", typeof(TCommand)));
            }

            await handler.Execute(command);
        }
    }
}