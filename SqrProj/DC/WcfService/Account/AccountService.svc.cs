using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Sqr.DC.EF.Models;
using Sqr.DC.BLL.Account;

namespace WcfService.Account
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“AccountService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 AccountService.svc 或 AccountService.svc.cs，然后开始调试。
    public class AccountService : IAccountService
    {
        public User GetUser(string account)
        {
            return new BLL_Account().GetUser(account);
        }

        public User ValidAndGet(string account, string password)
        {
            return new BLL_Account().ValidAndGetUser(account, password);
        }
    }
}
