using AutoMapper;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Infra.Auth.Service;
using MeusRendimentos.Services.Interfaces;
using MeusRendimentos.Services.Models;
using System;

namespace MeusRendimentos.Services.Services
{
    public class LoginService : BaseService, ILoginService
    {
        #region Propriedades Privadas
        private readonly IMapper _mapper;
        private readonly ILoginRepository _repositorio;
        #endregion

        #region Construtor
        public LoginService(ILoginRepository repositorio, IMapper mapper)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        #endregion

        #region Métodos Públicos
        public LoginModel logar(string email, string senha)
        {
            return _mapper.Map<LoginModel>(_repositorio.logar(email, senha));
        }

        public UsuarioAuthenticateResponseModel Authenticate(UsuarioAuthenticateRequestModel usuario)
        {
            var _usuario = _repositorio.logar(usuario.Email, usuario.Senha);

            if (_usuario == null)
                return null;

            var resultado = new UsuarioAuthenticateResponseModel(_mapper.Map<LoginModel>(_usuario), TokenService.GenerateToken(_usuario));

            resultado.Login.Senha = "";

            return resultado;
        }
        #endregion
    }
}
