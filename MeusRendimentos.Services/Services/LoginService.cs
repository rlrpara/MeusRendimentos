using AutoMapper;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.Interfaces;
using MeusRendimentos.Services.Models;

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
        #endregion
    }
}
