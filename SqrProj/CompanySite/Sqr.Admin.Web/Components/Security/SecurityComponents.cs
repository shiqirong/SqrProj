using Sqr.Admin.App.Api.DC.Dtos;
using Sqr.Admin.App.Base;
using Sqr.Admin.App.Security;
using Sqr.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sqr.Common.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Sqr.Admin.Web.Components.Security
{
    public class SecurityComponents: ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(string method)
        {
            switch(method)
            {
                case "GetMenuList":
                    return await GetMenuList();
                default:
                    return null;
            }
        }
        async Task<IViewComponentResult> GetMenuList()
        {
            //var model = await new SecurityBusiness().GetMenuList(1, SystemInfo.SystemId);
            //var items= model?.MapTo<List<GetMenuListOutput>>();
            return View("TopMenu");
        }
    }
}
