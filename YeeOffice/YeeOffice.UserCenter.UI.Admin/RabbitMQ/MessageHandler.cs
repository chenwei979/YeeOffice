﻿using ProtoBuf;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
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
                var message = Deserialize(ea.Body);
                Hand(message);
            };
            Channel.BasicConsume(queue: queueName, noAck: true, consumer: Consumer);
        }

        public void Dispose()
        {
            Channel.Dispose();
            Connection.Dispose();
        }

        public abstract void Hand(TMessage message);

        public TMessage Deserialize(byte[] message)
        {
            var stream = new MemoryStream(message, false);
            stream.Position = 0;
            return Serializer.Deserialize<TMessage>(stream);
        }
    }
}
