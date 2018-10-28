using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.WebApi;
using Sqr.Common.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sqr.DC.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            AutofacConfig.Configure(builder =>
            {
                //得到你的HttpConfiguration.
                var configuration = GlobalConfiguration.Configuration;


                var types = Assembly.Load("Sqr.DC.Business").GetTypes().Where(c => c.IsSubclassOf(typeof(Autofac.Module)));
                ///builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
                builder.RegisterAssemblyModules(Assembly.Load("Sqr.DC.Business"));
                builder.RegisterAssemblyModules(Assembly.Load("Sqr.DC.EF"));

                //注册控制器
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
                //可选：注册Autofac过滤器提供商.
                builder.RegisterWebApiFilterProvider(configuration);


                //builder.RegisterType(typeof(MyAuthenticationAttribute)).PropertiesAutowired(); //单独注册我们的MyAuthenticationAttribute过滤器
                var webapiAssembly = Assembly.Load("Sqr.DC.WebApi");

                //注册webapi项目中现实了IAuthorizationFilter接口或者实现了IActionFilter接口的非抽象过滤器类
                builder.RegisterAssemblyTypes(webapiAssembly).Where(r => !r.IsAbstract &&
                (typeof(IAuthorizationFilter).IsAssignableFrom(r)) || typeof(IActionFilter).IsAssignableFrom(r)).PropertiesAutowired();


                //对Repositorys这个程序集实现了IBaseRepository接口的非抽象类进行注册
                //var repository = Assembly.Load("Repositorys");
                //builder.RegisterAssemblyTypes(repository).Where(r => !r.IsAbstract).AsImplementedInterfaces().SingleInstance()
                //   .PropertiesAutowired();


                IContainer container = builder.Build();
                //将依赖关系解析器设置为Autofac。
                var resolver = new AutofacWebApiDependencyResolver(container);
                configuration.DependencyResolver = resolver;
                return container;
                //builder.Populate(services);
            });

            
        }
    }
}
