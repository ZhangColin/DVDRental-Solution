namespace DVDRenatal.Infrastructure.Messages
{
    public interface IMessageBus
    {
        void Send<TMessage>(TMessage message) where TMessage : IMessage;
    }
}