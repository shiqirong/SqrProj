using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sqr.Admin.App.Api.DC;
using Sqr.Admin.Web.Models;
using Sqr.Admin.Web.Models.RoleManager;
using Sqr.Common;
using Sqr.Common.Paging;
using Sqr.DC.Dtos.Account;
using Sqr.Common.Helper;

namespace Sqr.Admin.Web.Controllers
{
    public class RoleManagerController : ControllerAdminBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetPaged(PagingInput<RolesDto> input)
        {
            var output = (RolesApi.Instance.GetPaged(input).GetAwaiter().GetResult());
            if(output==null)
                return Json(new LayuiTablePagedOutput<RolesDto>()
                {
                    Count = 0,
                    Data = null
                });
            return Json(new LayuiTablePagedOutput<RolesDto>()
            {
                Count = output.Data.Total,
                Data = output.Data.Rows
            });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(RolesDto user)
        {
            var output = RolesApi.Instance.Add(user).GetAwaiter().GetResult();
            if (output.IsError)
            {
                return Json(new ResultMo()
                {
                    Code = ResultCode.Error,
                    Message = "操作异常！"
                });
            }
            else
            {
                return Json(output);
            }

        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var result = RolesApi.Instance.Get(id).GetAwaiter().GetResult();
            return View(result.Data.MapTo<VM_Role_Add>());
        }

        [HttpPost]
        public JsonResult Edit(RolesDto user)
        {
            var output = RolesApi.Instance.Update(user).GetAwaiter().GetResult();
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
            var output = RolesApi.Instance.Delete(new RolesDto() { Id = id }).GetAwaiter().GetResult();
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
    }
}