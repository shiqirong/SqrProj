using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sqr.Admin.App.Api.DC.Dtos;
using Sqr.Admin.App.Base;
using Sqr.Admin.App.News;
using Sqr.Admin.App.Security;
using Sqr.Admin.Web.Controllers;
using Sqr.Admin.Web.Models.News;
using Sqr.Common.Helper;
using Sqr.Common.Response;

namespace WebSite.Controllers
{
    public class MenuController : ControllerAdminBase
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> AllMenu()
        {
            return Json(await new SecurityBusiness().GetAllMenuTree());
        }

        [HttpGet]
        public async  Task<IActionResult> Edit(long id)
        {
            var menu=await new SecurityBusiness().GetActionInfo(id);
            return View(menu);
        }

        [HttpPost]
        public async Task<JsonResult> Edit(ActionInfo model)
        {
            return Json( await new SecurityBusiness().UpdateActionInfo(model));
        }

    }
}