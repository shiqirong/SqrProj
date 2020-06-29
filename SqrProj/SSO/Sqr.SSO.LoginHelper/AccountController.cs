using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sqr.Common;
using Sqr.SSO.Web.API.DC;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sqr.SSO.LoginHelper
{
    [AllowAnonymous]
    [Route("SSO/[controller]/[Action]")]
    public class AccountController:Controller
    {

        [HttpGet]
        public async Task<IActionResult> SsoLogin(string accessCode)
        {
            //如果用户已经登录，直接跳转到登录成功页面
            var checkResult=await DcAPI.Instance.CheckIsLogin(accessCode);
            if (!checkResult.IsSuccess)
                return new EmptyResult();
            if (checkResult.NotNullData().IsLogin)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,checkResult.NotNullData().UserInfo.Name)
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims,"SsoLogin");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                return new EmptyResult();
            }
            else
            {
                return new JsonResult(new ResultMo(ResultCode.NotLogin, "您还未登录。"));
            }

        }

        public IActionResult Login(string returnUrl)
        {
            var ssoLoginUrl=Sqr.Common.Utils.ConfigUtil.GetSection("SsoConfig").GetSection("LoginUrl").Value;
            return Redirect($"{ssoLoginUrl}?returnUrl={Common.Web.RequestHelper.GetAbsoluteUri(HttpContext.Request,returnUrl)}");
        }
    }
}
