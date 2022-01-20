using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Infra.Data.Repositories;
using MeusRendimentos.Services.Interfaces;
using MeusRendimentos.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeusRendimentos.Infra.CrossCutting
{
    public static class NativeInjector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            #region Services
            services.AddTransient<ICartaoService, CartaoService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IDespesaService, DespesaService>();
            services.AddTransient<IGanhoService, GanhoService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IMesService, MesService>();
            services.AddTransient<ITipoService, TipoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            #endregion

            #region Repositories
            services.AddTransient<ICartaoRepository, CartaoRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IDespesaRepository, DespesaRepository>();
            services.AddTransient<IGanhoRepository, GanhoRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IMesRepository, MesRepository>();
            services.AddTransient<ITipoRepository, TipoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IBaseRepository, BaseRepository>();

            #endregion
        }
    }
}
