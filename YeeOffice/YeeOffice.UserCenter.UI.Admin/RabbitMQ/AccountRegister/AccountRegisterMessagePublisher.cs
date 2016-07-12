using YeeOffice.UserCenter.Entities;

namespace YeeOffice.UserCenter.UI.Admin.RabbitMQ.AccountRegister
{
    public class AccountRegisterMessagePublisher : MessagePublisher<UserEntity>
    {
        public override void Push(UserEntity message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            Channel.BasicPublish(exchange: string.Empty, routingKey: "hello", basicProperties: null, body: body);
        }
    }
}
