using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sqr.Admin.App.Api.DC;
using Sqr.Admin.Web.Models;
using Sqr.Common;
using Sqr.DC.Dtos.Account;

namespace Sqr.Admin.Web.Controllers
{
    public class UserManagerController : ControllerAdminBase
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public JsonResult GetUserPaged(GetUserPagedInput input)
        {
            var output=(UserApi.Instance.GetUserPaged(input).GetAwaiter().GetResult());
            if (output.IsHasData)
            {
                return Json(new LayuiTablePagedOutput<UserDto>()
                {
                    Count = output.Data.Total,
                    Data = output.Data.Rows
                });
            }
            else
                return Json(new LayuiTablePagedOutput<UserDto>()
                {
                    Count = 0,
                    Data = null
                });
        }
        

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(UserDto user)
        {

            var output = UserApi.Instance.Add(user).GetAwaiter().GetResult();
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

        [HttpGet]
        public IActionResult Edit(long id)
        {
            return View();
        }

        [HttpPost]
        public JsonResult Edit(UserDto user)
        {
            var output = UserApi.Instance.Update(user).GetAwaiter().GetResult();
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

            var output = UserApi.Instance.Delete(new UserDto() { Id = id }).GetAwaiter().GetResult();
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

        //public JsonResult AssignRights()
        //{

        //}
    }
}