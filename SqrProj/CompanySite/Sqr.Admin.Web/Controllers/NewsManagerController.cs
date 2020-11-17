using Microsoft.AspNetCore.Mvc;
using Sqr.Admin.App.News;
using Sqr.Admin.Web.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sqr.Common.Helper;

namespace Sqr.Admin.Web.Controllers
{
    public class NewsManagerController:  ControllerAdminBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
