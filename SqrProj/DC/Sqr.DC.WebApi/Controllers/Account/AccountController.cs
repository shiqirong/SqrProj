using Microsoft.AspNetCore.Mvc;
using Sqr.Common;
using Sqr.Common.Logger;
using Sqr.DC.Entities;
using Sqr.DC.Services;
using Sqr.DC.Services.Account;
using Sqr.DC.Services.Account.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.DC.WebApi.Controllers.Account
{
    
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AccountController: ControllerBase
    {
        private static readonly AccountService _accountService = new AccountService();

        [HttpGet]
        public async Task<ResultMo<string>> Login(string input)
        {
            try
            {
                var t = await _accountService.Login(new LoginInput()
                {
                    Account = "aa",
                    Password = "fd"
                });
            }
            catch(Exception ex)
            {
                LoggerManager.CurrentLogger().Error(ex.ToString());
            }
            return new ResultMo<string>(input);
        }

        [HttpPost]
        public async Task<ResultMo<LoginOutput>> Login(LoginInput input)
        {
            if (!ModelState.IsValid)
                return new ResultMo<LoginOutput>(ResultCode.ParamsIncrect,string.Join('\n',ModelState.Select(c=>c.Value)));
            return await _accountService.Login(input);
        }

        /// <summary>
        /// 获取访问口令
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultMo<dynamic>> GetOrCreateAccessCode(long userId)
        {
            return await _accountService.GetOrCreateAccessCode(userId);
        }

        /// <summary>
        /// 获取SSO站点
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResultMo<IList<SsoSites>>> GetSSOSites()
        {
            return await new SsoSitesService().GetSSOSites();
        }

        /// <summary>
        /// 检查是否登录，及获取登录信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultMo<CheckIsLoginOutput>> CheckIsLogin(CheckIsLoginInput input)
        {
            return await _accountService.CheckIsLogin(input);
        }
    }
}
