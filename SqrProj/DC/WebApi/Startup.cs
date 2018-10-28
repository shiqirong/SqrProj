using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sqr.Common.IOC;
using System.Reflection;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            SwaggerConfig.Register(services);
            return AutofacConfig.Configure(builder =>
            {
                var types = Assembly.Load("Sqr.DC.Business").GetTypes().Where(c => c.IsSubclassOf(typeof(Autofac.Module)));
                builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
                builder.RegisterAssemblyModules(Assembly.Load("Sqr.DC.Business"));
                builder.RegisterAssemblyModules(Assembly.Load("Sqr.DC.EF"));
                builder.Populate(services);
                return null;
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(action =>
            {
                action.ShowExtensions();
                action.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });
            System.Diagnostics.Debug.WriteLine("register business module1");
        }
    }
}
