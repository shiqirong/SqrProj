﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sqr.Common;
using Sqr.Common.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.WebApi.Fillter
{
    public class GlobalActionFilter : IActionFilter,IResultFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("接口输入。");
            sb.Append("接口地址：");
            sb.Append(RequestHelper.GetAbsoluteUri(context.HttpContext.Request));
            sb.Append("接口输入内容：");
            sb.Append(context.HttpContext.Request.Body.);
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult)
            {
                var currentJsonResult = context.Result as ObjectResult;
                context.Result = new JsonResult(new ResultMo<object>()
                {
                    Code= ResultCode.Success,
                    Data= currentJsonResult.Value
                });
            }
            else if(context.Result is JsonResult)
            {
                var currentJsonResult = context.Result as JsonResult;
                context.Result = new JsonResult(new ResultMo<object>()
                {
                    Code = ResultCode.Success,
                    Data = currentJsonResult.Value
                });
            }
        }
    }
}
