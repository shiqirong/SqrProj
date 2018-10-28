using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.BLL
{
    public class BllModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BllModule).Assembly).Where(r => !r.IsAbstract &&
            (typeof(BLL_Base).IsAssignableFrom(r)) ).PropertiesAutowired();

        }
    }
}
