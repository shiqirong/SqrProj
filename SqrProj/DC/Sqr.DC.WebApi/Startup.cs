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
using Microsoft.Extensions.Options;
using Sqr.DC.WebApi.Fillter;

namespace Sqr.DC.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public  IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(sg =>
            {
                sg.SwaggerDoc("refuge", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "我的第一个 Swagger",
                    Version = "版本1"
                });

                var baseDirectory = AppContext.BaseDirectory;
                var currentNamespace = "Sqr.DC.WebApi";
                var xmlFiles = new[]
                {
                    $"{baseDirectory}\\{currentNamespace}\\Sqr.DC.WebApi.xml"
                };
                foreach (var xml in xmlFiles)
                {
                    if (System.IO.File.Exists(xml))
                        sg.IncludeXmlComments(xml);
                }
            });

            Action<MvcOptions> filters = new Action<MvcOptions>(r =>
            {
                r.Filters.Add(typeof(GlobalExceptionFilter));
                r.Filters.Add(typeof(GlobalActionFilter));
            });
            services.AddMvc(filters).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //ConsulCommon.ConsulRegistry.Configuration = Configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/refuge/swagger.json", "My API 1.0.1");//注意,中间那段的名字 (refuge) 要和 上面 SwaggerDoc 方法定义的 名字 (refuge)一样
                s.RoutePrefix = string.Empty; //默认值是 "swagger" ,需要这样请求:https://localhost:44384/swagger
            });
            app.UseMvc();

            ConsulCommon.ConsulRegistry.ConsulRegister();
        }
    }
}
