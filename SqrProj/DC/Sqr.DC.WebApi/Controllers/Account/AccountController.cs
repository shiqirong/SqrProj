using Microsoft.AspNetCore.Mvc;
using Sqr.Common;
using Sqr.Common.Logger;
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
        [HttpGet]
        public async Task<ResultMo<string>> Login(string input)
        {
            try
            {
                var t = await new AccountService().Login(new LoginInput()
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
            return await new AccountService().Login(input);
        }
    }
}
