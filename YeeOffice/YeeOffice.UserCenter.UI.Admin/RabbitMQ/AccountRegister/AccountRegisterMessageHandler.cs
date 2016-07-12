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

            //回调，当consumer收到消息后会执行该函数
            

            
        }
    }
}
