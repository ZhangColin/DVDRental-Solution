namespace DVDRenatal.Infrastructure.Messages
{
    public interface IMessageHandler<in TMessage> where TMessage : IMessage {
        void Execute(TMessage message);
    }
}