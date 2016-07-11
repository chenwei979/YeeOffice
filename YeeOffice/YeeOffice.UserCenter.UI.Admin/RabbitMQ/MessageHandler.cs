using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YeeOffice.UserCenter.UI.Admin.RabbitMQ
{
    public abstract class MessageHandler<TMessage> : IMessageHandler<TMessage>
    {
        protected IConnection Connection { get; set; }
        protected IModel Channel { get; set; }

        public MessageHandler()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();
        }

        public void Dispose()
        {
            Channel.Dispose();
            Connection.Dispose();
        }

        public abstract void Hand(TMessage message);
    }
}
