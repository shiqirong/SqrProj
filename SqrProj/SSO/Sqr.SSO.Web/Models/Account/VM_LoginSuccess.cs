using Sqr.SSO.Web.API.DC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.SSO.Web.Models.Account
{
    public class VM_LoginSuccess
    {
        /// <summary>
        /// SSO站点集合
        /// </summary>
        public IList<M_SSOSite> SSOSites { get; set; }

        /// <summary>
        /// 授权码
        /// </summary>
        public string AuthCode { get; set; }
        public string ReturnUrl { get; internal set; }
    }
}
