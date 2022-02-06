using MeusRendimentos.Infra.Auth.Models;
using MeusRendimentos.Infra.CrossCutting;
using MeusRendimentos.Infra.Database;
using MeusRendimentos.Infra.Swagger;
using MeusRendimentos.Services.AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            DatabaseConfiguration.GerenciarBanco();
            services.AddControllers()
                .AddJsonOptions(x => {
                    x.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .AddNewtonsoftJson(x => {
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
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

            app.UseSwaggerConfiguration();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseSpaStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(x =>
            {
                x.Options.SourcePath = "MeusRendimentosUi";

                if (env.IsDevelopment())
                {
                    x.UseProxyToSpaDevelopmentServer($"http://localhost:3000");
                }
            });
        }
    }
}
