using AutoMapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Services.Models;

namespace MeusRendimentos.Services.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain
            CreateMap<CartaoModel, Cartao>();
            CreateMap<CategoriaModel, Categoria>();
            CreateMap<DespesaModel, Despesa>();
            CreateMap<GanhoModel, Ganho>();
            CreateMap<LoginModel, Login>();
            CreateMap<MesModel, Mes>();
            CreateMap<TipoModel, Tipo>();
            CreateMap<UsuarioModel, Usuario>();
            #endregion

            #region DomainToViewModel
            CreateMap<Cartao, CartaoModel>();
            CreateMap<Categoria, CategoriaModel>();
            CreateMap<Despesa, DespesaModel>();
            CreateMap<Ganho, GanhoModel>();
            CreateMap<Login, LoginModel>();
            CreateMap<Tipo, TipoModel>();
            CreateMap<Usuario, UsuarioModel>();
            #endregion
        }
    }
}
