using Sqr.Common;
using Sqr.Common.Cache;
using Sqr.Common.Encrypt;
using Sqr.Common.Exceptions;
using Sqr.Common.Helper;
using Sqr.DC.Entities;
using Sqr.DC.Repositories;
using Sqr.DC.Services.Account.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.Services.Account
{
    public class AccountService:ServiceBase<AccountService>
    {
        public async Task<LoginOutput> Login(LoginInput input)
        {
            var result= await new UsersRepository().GetByAccoutAsync(input.Account);
            if (result == null)
                throw new DataNullException("账号不存在");
            if (!result.Password.Equals(Md5.EncryptHexString(input.Password), StringComparison.CurrentCulture))
            {
                throw new DataNullException("密码不正确"); 
            }

            result.Password = string.Empty;

            //await GetOrCreateAccessCode(result.Id);

            return new LoginOutput()
            {
                UserInfo = result
            };
        }

        /// <summary>
        /// 获取访问口令
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public async Task<dynamic> GetOrCreateAccessCode(long userId)
        {
            var userInfo=new UsersRepository().GetByIdSingle(userId);
            var accessCode = Guid.NewGuid().ToString();
            if (!CacheManager.CurrentCache().Set($"AccessCode_{accessCode}", userInfo, TimeSpan.FromMinutes(1)))
            {
                throw new Exception( "设置AccessCode失败");
            }
            return await Task.FromResult( new { accessCode });
        }
        

        /// <summary>
        /// 检查是否登录，及获取登录信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CheckIsLoginOutput> CheckIsLogin(CheckIsLoginInput input)
        {
            var item = CacheManager.CurrentCache().Get<Users>("AccessCode_" + input.AccessCode);
            return await Task.FromResult(new CheckIsLoginOutput()
            {
                IsLogin = item != null,
                UserInfo = item
            });
        }
    }

}
