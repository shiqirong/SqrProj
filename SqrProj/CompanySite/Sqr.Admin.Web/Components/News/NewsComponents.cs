using Microsoft.AspNetCore.Mvc;
using Sqr.Admin.App.News;
using Sqr.Admin.Web.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sqr.Common.Helper;
using Sqr.Common.Response;

namespace Sqr.Admin.Web.Components.News
{
    public class NewsComponents:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        {
            var items = await NewsWindow();
            return View("NewsWindow", items);
        }

        async Task<PageResult<VM_News>> NewsWindow()
        {
            var rm = await new NewsBusiness().GetNewsList(new Sqr.Admin.App.Api.DC.Dtos.GetNewsListInput()
            {
                PageIndex = 1,
                PageSize = 20
            });

            if (rm.IsSuccess)
                return rm.Data?.MapTo<PageResult<VM_News>>();
            else
                return null;
        }
    }
}
