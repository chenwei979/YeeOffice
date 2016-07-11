using YeeOffice.UserCenter.Entities;

namespace YeeOffice.UserCenter.UI.Admin.RabbitMQ.AccountRegister
{
    public class AccountRegisterMessagePublisher : MessagePublisher<UserEntity>
    {
        public override void Push(UserEntity message)
        {
            //var message = "Hello World!";
            //var body = Encoding.UTF8.GetBytes(message);

            ////向该消息队列发送消息message
            //Channel.BasicPublish(exchange: "",
            //    routingKey: "hello",
            //    basicProperties: null,
            //    body: body);
        }
    }
}
