using System;

namespace YeeOffice.UserCenter.UI.Admin.RabbitMQ
{
    public interface IMessageHandler<TMessage> : IDisposable
    {
        void Hand(TMessage message);
    }
}
