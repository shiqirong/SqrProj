using Sqr.SSO.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sqr.SSO.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string from)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Sqr.SSO.Web.Models.Account.VM_Login model)
        {
            if (ModelState.IsValid)
            {
                var user=new BLL_User().ValidAndGet(model.Account, model.Password);
                if (user != null)
                {
                    ModelState.AddModelError("", "登录成功");
                }
                ModelState.AddModelError("", "用户名或密码不正确");
            }
            return View(model);
        }
    }
}