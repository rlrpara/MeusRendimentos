using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Infra.Data.Repositories;
using MeusRendimentos.Services.Interfaces;
using MeusRendimentos.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
            services.AddTransient<ITipoPassagemRepository, TipoPassagemRepository>();
            services.AddTransient<ITrajetoRepository, TrajetoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IViagemRepository, ViagemRepository>();
            services.AddTransient<IBaseRepository, BaseRepository>();

            #endregion
        }
    }
}
