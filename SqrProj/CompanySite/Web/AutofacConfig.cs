using Autofac;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebSite
{
    public class AutofacConfig
    {
        public void Setup()
        {
            var builder = new ContainerBuilder();
            //注册Controller
            builder.RegisterTypes(Assembly.GetExecutingAssembly().GetTypes().Where(c => c.IsAssignableFrom(typeof(ControllerBase))).ToArray());
            //注册Business
            builder.RegisterTypes(Assembly.GetExecutingAssembly().GetTypes().Where(c => c.Name.EndsWith("Business")).ToArray());
            //注册Repository
            builder.RegisterTypes(Assembly.GetExecutingAssembly().GetTypes().Where(c => c.Name.EndsWith("Repository")).ToArray());
        }
    }
}
