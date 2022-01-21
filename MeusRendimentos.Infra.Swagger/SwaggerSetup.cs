using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace MeusRendimentos.Infra.Swagger
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Meus Rendimentos!",
                    Version = "v1",
                    Description = "Api de controle financeiro desenvolvida em .Net Core 3.1",
                    Contact = new OpenApiContact
                    {
                        Name = "Rodrigo de L. Ribeiro",
                        Email = "rlr.para@gmail.com"
                    }
                });

                x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api-doc.xml"));
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(x =>
            {
                x.RoutePrefix = "documentation";
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });
        }
    }
}
