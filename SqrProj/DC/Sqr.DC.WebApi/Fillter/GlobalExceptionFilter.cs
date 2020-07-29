using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sqr.Common;
using Sqr.Common.Logger;
using Sqr.Common.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqr.DC.WebApi.Fillter
{

    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            
            filterContext.Result = new JsonResult( new ResultMo(ResultCode.Error,$"{filterContext.Exception.Message}") );
            filterContext.ExceptionHandled = true;

            string controllerName = (string)filterContext.RouteData.Values["controller"];
            string actionName = (string)filterContext.RouteData.Values["action"];

            LoggerManager.CurrentLogger().Error($"访问接口出现异常。接口地址：{RequestHelper.GetAbsoluteUri(filterContext.HttpContext.Request)}，错误信息：{filterContext.Exception.StackTrace}");

        }

    }
}
