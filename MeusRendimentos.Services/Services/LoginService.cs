using AutoMapper;
using MeusRendimentos.Domain.Interfaces;
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
        public LoginService(ILoginRepository repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion

        #region Métodos Públicos
        public LoginModel logar(string email, string senha)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
