using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqr.Common.Web
{
    public static class RequestHelper
    {
        public static string GetAbsoluteUri(HttpRequest request)
        {
            return new StringBuilder()
                .Append(request.Scheme)
                .Append("://")
                .Append(request.Host)
                .Append(request.PathBase)
                .Append(request.Path)
                .Append(request.QueryString)
                .ToString();
        }

        public static string GetAbsoluteUri(HttpRequest request,string url)
        {
            if (url.StartsWith("http"))
            {
                return url;
            }
            else
            {
                return new StringBuilder()
               .Append(request.Scheme)
               .Append("://")
               .Append(request.Host)
               .Append(url)
               .ToString();
            }
           
        }

        public static string GetDomainName(HttpRequest request)
        {
            return new StringBuilder()
                .Append(request.Scheme)
                .Append("://")
                .Append(request.Host).ToString();
        }
    }
}
