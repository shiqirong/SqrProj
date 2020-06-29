using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.SSO.Web.API.DC.Dtos
{
    public class LoginInput
    {
        public string Account { get; set; }

        public string Password { get; set; }
        public string LoginId { get; internal set; }
    }

    public class LoginOutput
    {
        public UserInfo UserInfo { get; set; }
    }
}
