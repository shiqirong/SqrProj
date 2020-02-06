using Sqr.DC.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Services.Account.Dtos
{
    public class LoginInput
    {
        public string Account { get;  set; }
        public string Password { get;  set; }
    }

    public class LoginOutput
    {
        public Users UserInfo { get; set; }
    }
}
