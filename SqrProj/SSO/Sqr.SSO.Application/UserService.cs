using Sqr.SSO.Application.SsoWcfService;
using Sqr.SSO.Common;

namespace Sqr.SSO.Application
{
    public class UserService
    {
        public User GetUser(string account)
        {
            return WcfHelper.Using<ISsoService,User>(c => { return c.GetUser(account); });
        }

        public ResponseResult<User> ValidAndGet(string account, string password)
        {
            var user = WcfHelper.Using<ISsoService, User>(c => { return c.ValidAndGet(account, password); });
            if (user == null)
            {
                return new ResponseResult<User>()
                {
                    Code = 2,
                    Msg = "用户名或密码不正确！"
                };
            }

            TokenManager tokenMng = new TokenManager();
            var token=tokenMng.Add(user);

            return new ResponseResult<User>()
            {
                Code = 1,
                Tag=token
            };
        }
    }
}
