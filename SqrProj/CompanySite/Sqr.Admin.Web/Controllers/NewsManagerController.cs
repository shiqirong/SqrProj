using Microsoft.AspNetCore.Mvc;
using Sqr.Admin.App.News;
using Sqr.Admin.Web.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sqr.Common.Helper;
using Sqr.DC.Dtos.News;
using Sqr.Admin.App.Api.DC;
using Sqr.Admin.Web.Models;
using Sqr.Common;

namespace Sqr.Admin.Web.Controllers
{
    public class NewsManagerController:  ControllerAdminBase
    {
        [HttpGet]
        public JsonResult GetNewsPaged(NewsInfoQueryDto input, int page, int limit)
        {
            var output = NewsApi.Instance.GetNewsPaged(input, page, limit).GetAwaiter().GetResult();
            if (output.IsHasData)
            {
                return Json(new LayuiTablePagedOutput<NewsInfoDto>()
                {
                    Count = output.Data.Total,
                    Data = output.Data.Rows
                });
            }
            else
                return Json(new LayuiTablePagedOutput<NewsInfoDto>()
                {
                    Count = 0,
                    Data = null
                });
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(VM_News model)
        {
            var result = NewsApi.Instance.Add(model.MapTo<NewsInfoDto>()).GetAwaiter().GetResult();
            return Json(result);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var result=NewsApi.Instance.Get(id).GetAwaiter().GetResult();
            return View(result.Data.MapTo<VM_News>());

        }

        [HttpPost]
        public JsonResult Edit(VM_News model)
        {
            var output = NewsApi.Instance.Update(model.MapTo<NewsInfoDto>()).GetAwaiter().GetResult();
            if (output.IsError)
            {
                return Json(new ResultMo()
                {
                    Code = ResultCode.Error,
                    Message = "操作失败！"
                });
            }
            else
            {
                return Json(output);
            }
        }

        [HttpPost]
        public JsonResult Delete(long id)
        {
            var output = NewsApi.Instance.Delete(id).GetAwaiter().GetResult();
            if (output.IsError || !output.Data)
            {
                return Json(new ResultMo()
                {
                    Code = ResultCode.Error,
                    Message = "操作失败！"
                });
            }
            else
            {
                return Json(output);
            }
        }
    }
}
