using ProtoBuf;
using System.IO;
using YeeOffice.UserCenter.Entities;

namespace YeeOffice.UserCenter.UI.Admin.RabbitMQ.AccountRegister
{
    public class AccountRegisterMessagePublisher : MessagePublisher<UserEntity>
    {
        public override void Push(UserEntity message)
        {
            var bytes = Serialize(message);
            Channel.BasicPublish(exchange: string.Empty, routingKey: "hello", basicProperties: null, body: bytes);
        }
    }
}
