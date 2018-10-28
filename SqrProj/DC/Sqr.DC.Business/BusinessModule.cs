using Autofac;
using Sqr.DC.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.BLL
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            System.Diagnostics.Debug.WriteLine("register business module");
            builder.RegisterAssemblyTypes(this.ThisAssembly).Where(c => c.IsSubclassOf(typeof(BaseBusiness)));
        }
    }
}
