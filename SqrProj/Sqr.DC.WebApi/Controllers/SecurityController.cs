using Sqr.Common;
using Sqr.DC.BLL.Security;
using Sqr.DC.BLL.Security.Dto;
using Sqr.DC.WebApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Sqr.DC.WebApi.Controllers
{
    public class SecurityController: BaseController
    {
        public BLL_Menu MenuBusiness { get; set; }

        [HttpGet]
        public SqrResponse<List<GetMenuListOutput>> GetMenuList(long accountId)
        {
            return SqrResponse<List<GetMenuListOutput>>.Ok(MenuBusiness.GetMenuList(accountId));
        }
    }
}