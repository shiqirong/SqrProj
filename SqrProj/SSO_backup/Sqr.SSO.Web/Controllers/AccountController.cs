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
                var response=new UserService().ValidAndGet(model.Account, model.Password);
                if (1==response.Code)
                {
                    HttpCookie cookie= new HttpCookie("SsoToken");
                    cookie.Value = response.Tag.ToString();
                    Request.Cookies.Add(cookie);
                    return RedirectToActionPermanent("setCookie", new {token=response.Tag, returnUrl= Request.Params["returnUrl"] });
                }
                else
                {
                    ModelState.AddModelError("", response.Msg);
                }
            }
            return View(model);
        }

        public ActionResult SetCookie(string token,string returnUrl)
        {
            var siteList=new SsoSiteService().GetSsoSiteList();
            if (siteList == null)
            {
                siteList = new List<Application.SsoWcfService.SsoSite>();
            }
            ViewBag.token = token;
            ViewBag.returnUrl = returnUrl;
            return View(siteList);
        }
    }
}