using Microsoft.Extensions.DependencyInjection;
using Sqr.Common.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApi
{
    public static class AutofacSetup
    {
        public static void Setup(IServiceCollection services)
        {
            var types = Assembly.Load("Sqr.DC.Business").GetTypes().Where(c => c.IsSubclassOf(typeof(Autofac.Module)));
            AutofacConfig.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            AutofacConfig.RegisterAssemblyModules(Assembly.Load("Sqr.DC.Business"));
            AutofacConfig.RegisterAssemblyModules(Assembly.Load("Sqr.DC.EF"));
            
            AutofacConfig.Build();
        }
    }
}
