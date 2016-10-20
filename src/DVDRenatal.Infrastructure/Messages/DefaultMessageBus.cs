using System;
using DVDRenatal.Infrastructure.CommandProcessor;
using DVDRenatal.Infrastructure.IoC;

namespace DVDRenatal.Infrastructure.Messages
{
    public class DefaultMessageBus: IMessageBus
    {
        public void Send<TMessage>(TMessage message) where TMessage : IMessage
        {
            var handler = ServiceLocator.GetService<IMessageHandler<TMessage>>();
            if (handler == null) {
                throw new Exception(string.Format("未找到消息处理器：{0}。", typeof(TMessage)));
            }

            handler.Execute(message);
        }
    }
}