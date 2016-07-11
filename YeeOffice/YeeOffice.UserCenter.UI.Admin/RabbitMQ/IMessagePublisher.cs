using System;

namespace YeeOffice.UserCenter.UI.Admin.RabbitMQ
{
    public interface IMessagePublisher<TMessage> : IDisposable
    {
        void Push(TMessage message);
    }
}
