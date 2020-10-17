using Microsoft.AspNetCore.Mvc;
using Sqr.Admin.App.Api.DC;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Account;
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
                
            var pagedOutput = await SecurityApi.Instance.GetActionPaged(new PagingInput<ActionDto>()
            {
                InputData=new ActionDto() {
                    Category = "1",
                    SystemId = 1,
                },
                Page = 1,
                Limit = int.MaxValue
            });
            return View("SideMenu", pagedOutput.Data?.Rows);
        }

    }
}
