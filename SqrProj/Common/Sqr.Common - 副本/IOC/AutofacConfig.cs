using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.Common.IOC
{
    public class AutofacConfig
    {
        /// <summary>
        /// 禁止使用这个对象去 注入（创建实例）服务。会出现各种问题!!!!-后面要去掉这个~！
        /// </summary>
        public static IContainer Container = null;

        /// <summary>
        /// 兼容Hangfire
        /// </summary>
        public static TService Resolve<TService>(bool useTaggedLifetimeScope = true)
        {
            //if (HttpContext.Current != null)
            //{
                return Container.Resolve<TService>();
            //}
            //else
            //{
            //    var activator = new AutofacJobActivator(Container, useTaggedLifetimeScope);
            //    using (var scope = activator.BeginScope())
            //    {
            //        return (TService)scope.Resolve(typeof(TService));
            //    }
            //}
        }
    }
}
