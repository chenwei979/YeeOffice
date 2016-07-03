using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YeeOffice.UserCenter.BusnissLogic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace YeeOffice.UserCenter.UI.Admin.Controllers
{
    public class AccountController : Controller
    {
        public UserBusnissLogic BusnissLogic { get; set; }

        public AccountController(UserBusnissLogic busnissLogic)
        {
            BusnissLogic = busnissLogic;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var logined = BusnissLogic.Login(username, password);

            if (logined) return Redirect("/Home/Index/");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string displayname, string username, string password)
        {
            var success = BusnissLogic.Register(displayname, username, password);

            if (success) return Redirect("/Home/Index/");
            return View();
        }
    }
}
