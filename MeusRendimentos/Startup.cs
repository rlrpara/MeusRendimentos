using MeusRendimentos.Infra.CrossCutting;
using MeusRendimentos.Infra.Swagger;
using MeusRendimentos.Services.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace MeusRendimentos
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSpaStaticFiles(diretorio =>
            {
                diretorio.RootPath = "MeusRendimentosUi/dist";
            });
            services.AddAutoMapper(typeof(AutoMapperSetup));
            services.AddSwaggerConfiguration();
            NativeInjector.RegisterServices(services, Configuration);
            services.AddControllers()
                .AddJsonOptions(x => {
                    x.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .AddNewtonsoftJson(x => {
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseSpaStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(x =>
            {
                //x.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "MeusRendimentosUi");
                x.Options.SourcePath = "MeusRendimentosUi";

                if (env.IsDevelopment())
                {
                    x.UseProxyToSpaDevelopmentServer($"http://localhost:4200");
                }
            });
        }
    }
}
