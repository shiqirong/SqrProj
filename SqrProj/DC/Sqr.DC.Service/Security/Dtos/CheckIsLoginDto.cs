using Sqr.DC.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.DC.Services.Account.Dtos
{
    public class CheckIsLoginInput
    {
        public string AccessCode { get; set; }
    }

    public class CheckIsLoginOutput
    {
        public bool IsLogin { get; set; }

        public string LoginId { get; set; }

        public Users UserInfo { get; set; }
    }
}
