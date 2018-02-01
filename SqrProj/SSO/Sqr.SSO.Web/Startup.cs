using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(Sqr.SSO.Web.Startup))]
namespace Sqr.SSO.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}