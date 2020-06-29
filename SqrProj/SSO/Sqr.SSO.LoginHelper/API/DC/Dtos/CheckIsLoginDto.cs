using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.SSO.LoginHelper.API.DC.Dtos
{
    public class CheckIsLoginInput
    {
        public string AccessCode { get; set; }
    }

    public class CheckIsLoginOutput
    {
        public bool IsLogin { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}
