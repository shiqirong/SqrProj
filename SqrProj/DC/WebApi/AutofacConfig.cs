using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApi
{
    public class AutofacConfig
    {
        static ContainerBuilder _Builder = new ContainerBuilder();
        static IContainer _Container = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceProvider Configure(IServiceCollection services)
        {
            var types = Assembly.Load("Sqr.DC.Business").GetTypes().Where(c => c.IsSubclassOf(typeof(Autofac.Module)));
            _Builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            _Builder.RegisterAssemblyModules(Assembly.Load("Sqr.DC.Business"));
            _Builder.RegisterAssemblyModules(Assembly.Load("Sqr.DC.EF"));
            _Builder.Populate(services);
            _Container = _Builder.Build();
            return new AutofacServiceProvider(_Container);
        }
    }
}

