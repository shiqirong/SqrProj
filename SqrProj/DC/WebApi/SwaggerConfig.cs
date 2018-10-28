using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class SwaggerConfig
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version="v1",
                    Title="API",
                    Description="Api 文档",
                    TermsOfService="None"
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "WebApi.xml");
                var xmlPathBusiness = Path.Combine(basePath, "Sqr.DC.Business.xml");
                options.IncludeXmlComments(xmlPathBusiness);
                options.IncludeXmlComments(xmlPath,true);
                //options.OperationFilter<AddAuthTokenHeaderParameter>();
            });
        }
    }
}
