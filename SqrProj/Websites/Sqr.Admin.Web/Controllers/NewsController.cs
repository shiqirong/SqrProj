using Sqr.Admin.App.News;
using Sqr.Admin.Web.Models.News;
using Sqr.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sqr.Admin.Web.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public  PartialViewResult NewsWindow()
        {
            var model =  new NewsBusiness().GetNewsList(new App.Api.DC.Dtos.GetNewsListInput()
            {
                   PageIndex=1,
                   PageSize=20
            }).Result;
            var m = model.Rows.MapTo<List<VM_News>>();
            return PartialView(m);
        }
    }
}