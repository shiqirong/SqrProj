using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sqr.Common.Logger;
using Sqr.SSO.Web.Account.VModels;
using Sqr.SSO.Web.API.DC;

namespace Sqr.SSO.Web.Controllers
{
    public class AccountController :  Controller
    {
        
        public async Task<IActionResult> Login(string backUrl)
        {
            var LoginCode = HttpContext.Session.GetString("LoginCode");
            if (!string.IsNullOrWhiteSpace(LoginCode)){
                var retAccessCode=await DcAPI.Instance.GetOrCreateAccessCode(LoginCode);
                return RedirectToAction("LoginSuccess");
            }
            return View(new VM_Login()
            {
                BackUrl=backUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]VM_Login vmodel)
        {
            if (vmodel != null)
            {
                var validateCode = HttpContext.Session.GetString("ValidateCode");
                if (!validateCode.Equals(vmodel.ValidCode,StringComparison.CurrentCultureIgnoreCase))
                {
                    ModelState.AddModelError("ValidCode", "验证码不正确");
                }
            }
            if (!ModelState.IsValid)
            {
                return View(vmodel);
            }
            
            var result=await API.DC.DcAPI.Instance.Login(new API.DC.Dtos.LoginInput()
            {
                Account = vmodel.Account,
                Password = vmodel.Password
            });
            if (result.IsSuccess)
                return Redirect("http://www.baidu.com");
            return View(vmodel);
        }

        /// <summary>
        /// 登录验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetImg()
        {
            int width = 100;
            int height = 40;
            int fontsize = 20;
            string code = string.Empty;
            byte[] bytes = Common.Helper.ValidateCodeHelper.CreateValidateGraphic(out code, 4, width, height, fontsize);
            HttpContext.Session.SetString("ValidateCode", code);
            return File(bytes, @"image/jpeg");
        }

        public ActionResult LoginSuccess()
        {
            return View();
        }
    }
}