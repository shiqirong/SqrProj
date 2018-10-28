using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqr.DC.EF
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseRepository<>));
            builder.RegisterAssemblyTypes(this.ThisAssembly).Where(c => c.Name.EndsWith("Repository"));
        }
    }
}
