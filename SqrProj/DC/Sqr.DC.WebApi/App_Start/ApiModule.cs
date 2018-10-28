using Autofac;
using Module = Autofac.Module;

namespace Sqr.DC.WebApi
{
    public class ApiModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }
    }
}
