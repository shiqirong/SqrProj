using Sqr.Common;
using Sqr.Common.Encrypt;
using Sqr.Common.Helper;
using Sqr.DC.Repositories;
using Sqr.DC.Services.Account.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.Services.Account
{
    public class AccountService:ServiceBase
    {
        public async Task<ResultMo<LoginOutput>> Login(LoginInput input)
        {
            var result= await new UsersRepository().GetByAccoutAsync(input.Account);
            if (result == null)
                return new ResultMo<LoginOutput>(ResultCode.DataNotExists, "账号不存在");
            if (!result.Password.Equals(Md5.EncryptHexString(input.Password), StringComparison.CurrentCulture))
            {
                return new ResultMo<LoginOutput>(ResultCode.PasswordIncrect, "密码不正确");
            }

            result.Password = string.Empty;
            return new ResultMo<LoginOutput>(new LoginOutput()
            {
                UserInfo = result
            });
        }
    }

}
