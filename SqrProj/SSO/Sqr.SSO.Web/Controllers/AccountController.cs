using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sqr.SSO.Web.API.DC;
using Sqr.SSO.Web.Models.Account;
using System.Linq;

namespace Sqr.SSO.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController :  Controller
    {
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            //如果用户已经登录，直接跳转到登录成功页面
            if (User.Identity.IsAuthenticated)
            {
                return await LoginSuccess(returnUrl);
            }
            return View(new VM_Login()
            {
                ReturnUrl = returnUrl
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
                Password = vmodel.Password,
                LoginId= HttpContext.Session.Id
            });
            if (result.IsSuccess)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,result.NotNullData().UserInfo.Name),
                    new Claim(ClaimTypes.Sid,result.NotNullData().UserInfo.Id.ToString())
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims,"SsoLogin");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignOutAsync();
                await HttpContext.SignInAsync(principal);

                return await LoginSuccess(vmodel.ReturnUrl, result.NotNullData().UserInfo.Id);
            }

            return View(vmodel);
        }

        async Task<IActionResult> LoginSuccess(string returnUrl,long userId=0)
        {
            if(userId==0)
                userId = long.Parse(User.Claims.First(c => ClaimTypes.Sid.Equals(c.Type, StringComparison.CurrentCultureIgnoreCase)).Value);
            var ssoSites = await DcAPI.Instance.GetSSOSites();
            var retAccessCode = await DcAPI.Instance.GetOrCreateAccessCode(userId);

            return View("LoginSuccess", new VM_LoginSuccess()
            {
                AuthCode = retAccessCode.NotNullData().AccessCode,
                SSOSites = ssoSites.NotNullData(),
                ReturnUrl=string.IsNullOrWhiteSpace(returnUrl)? $"{Request.Scheme}://{Request.Host}" :returnUrl
            });
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
        
    }
}