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
            services.AddTransient<IEmpresaService, EmpresaService>();
            services.AddTransient<IPassageiroService, PassageiroService>();
            services.AddTransient<IPassagemService, PassagemService>();
            services.AddTransient<ITipoPassagemService, TipoPassagemService>();
            services.AddTransient<ITrajetoService, TrajetoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IViagemService, ViagemService>();

            #endregion

            #region Repositories
            services.AddTransient<IEmbarcacaoRepository, EmbarcacaoRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IPassagemRepository, PassagemRepository>();
            services.AddTransient<IPassageiroRepository, PassageiroRepository>();
            services.AddTransient<ITipoPassagemRepository, TipoPassagemRepository>();
            services.AddTransient<ITrajetoRepository, TrajetoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IViagemRepository, ViagemRepository>();
            services.AddTransient<IBaseRepository, BaseRepository>();

            #endregion
        }
    }
}
