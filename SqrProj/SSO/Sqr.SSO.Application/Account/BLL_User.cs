using Sqr.SSO.Application.AccountWcf;
using Sqr.SSO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.SSO.Application
{
    public class BLL_User
    {
        public User GetUser(string account)
        {
            return WcfHelper.Using<IAccountService,User>(c => { return c.GetUser(account); });
        }

        public ResponseResult<User> ValidAndGet(string account,string password)
        {
            var user= WcfHelper.Using<IAccountService, User>(c => { return c.ValidAndGet(account,password); });
            if(user!=null)
            {
                return new ResponseResult<User>()
                {
                    Code = 2,
                    Msg = "用户名或密码不正确！"
                };
            }
            else
            {
                return new ResponseResult<User>()
                {
                    Code=1,
                };
            }
        }
    }
}
