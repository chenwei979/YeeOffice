using RabbitMQ.Client.Events;
using System;
using System.Text;
using YeeOffice.UserCenter.Entities;

namespace YeeOffice.UserCenter.UI.Admin.RabbitMQ.AccountRegister
{
    public class AccountRegisterMessageHandler : MessageHandler<UserEntity>
    {
        public override void Hand(UserEntity message)
        {
            //创建一个名为"hello"的队列，防止producer端没有创建该队列
            Channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            //回调，当consumer收到消息后会执行该函数
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };

            //消费队列"hello"中的消息
            channel.BasicConsume(queue: "hello",
                                 noAck: true,
                                 consumer: consumer);
        }
    }
}
