using Microsoft.AspNetCore.Mvc;
using Sqr.Admin.App.Api.DC;
using Sqr.Admin.Web.Models.Product;
using Sqr.DC.Dtos.Co;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sqr.Common.Helper;
using Sqr.Common.Paging;
using Sqr.Admin.Web.Models;

namespace Sqr.Admin.Web.Controllers
{
    public class ProductManagerController : ControllerAdminBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("edit");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var result= ProductApi.Instance.Get(id).GetAwaiter().GetResult();
            return View(result.Data.MapTo<VM_Product>());
        }

        [HttpPost]
        public JsonResult Add(VM_Product m)
        {
            var result=ProductApi.Instance.Add( m.MapTo<ProductInfoDto>()).GetAwaiter().GetResult();
            return Json(result);
        }

        [HttpPost]
        public JsonResult Edit(VM_Product m)
        {
            var result = ProductApi.Instance.Update(m.MapTo<ProductInfoDto>()).GetAwaiter().GetResult();
            return Json(result);
        }

        [HttpPost]
        public JsonResult Delete(long id)
        {
            var result = ProductApi.Instance.Delete(id).GetAwaiter().GetResult();
            return Json(result);
        }

        [HttpGet]
        public JsonResult GetProductCategory()
        {
            var result = ProductApi.Instance.GetProductCategory().GetAwaiter().GetResult();
            return Json(result);
        }
        [HttpGet]
        public JsonResult GetPaged(ProductQueryDto input, int page, int limit)
        {
            var output = ProductApi.Instance.GetPaged(input,page,limit).GetAwaiter().GetResult();
            if (output.IsHasData)
            {
                return Json(new LayuiTablePagedOutput<ProductInfoDto>()
                {
                    Count = output.Data.Total,
                    Data = output.Data.Rows
                });
            }
            else
                return Json(new LayuiTablePagedOutput<ProductInfoDto>()
                {
                    Count = 0,
                    Data = null
                });
        }
    }
}
