using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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
        protected EventingBasicConsumer Consumer { get; set; }

        public MessageHandler()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();

            var queueName = this.GetType().FullName.Replace("Handler", string.Empty);
            Channel.QueueDeclare(queue: queueName,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            Consumer = new EventingBasicConsumer(Channel);
            Consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                
                var message = Encoding.UTF8.GetString(body);
            };
            Channel.BasicConsume(queue: queueName, noAck: true, consumer: Consumer);
        }

        public void Dispose()
        {
            Channel.Dispose();
            Connection.Dispose();
        }

        public abstract void Hand(TMessage message);
    }
}
