using Microsoft.AspNetCore.Mvc;
using Sqr.Admin.App.Api.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.Admin.Web.Components.Security
{
    public class SideMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pagedOutput = await SecurityApi.Instance.GetActionPaged(new DC.Dtos.Account.GetActionPagedInput()
            {
                Category = "1",
                SystemId = "1",
                PageIndex = 1,
                PageSize = int.MaxValue
            });
            return View("SideMenu", pagedOutput.Rows);
        }

    }
}
