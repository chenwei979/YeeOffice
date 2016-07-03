using Microsoft.AspNetCore.Mvc;
using YeeOffice.UserCenter.BusnissLogic;
using YeeOffice.UserCenter.Entities;

namespace Ak.Projects.Service.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public UserBusnissLogic BusnissLogic { get; set; }

        public UsersController(UserBusnissLogic busnissLogic)
        {
            BusnissLogic = busnissLogic;
        }

        //[HttpPost]
        [HttpGet]
        public string Index()
        {
            var user = new UserEntity();
            user.Account = "bruce.chen";
            user.Password = "123";
            user.DisplayName = "Bruce Chen";
            BusnissLogic.Save(user);
            return "value";
        }
    }
}
