using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;

namespace MeusRendimentos.Infra.Data.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        private readonly IBaseRepository _repositorio;
        public LoginRepository(IBaseRepository repositorio)
        {
            _repositorio = repositorio;
        }
        public Login logar(string email, string senha)
        {
            return _repositorio.BuscarPorQueryGerador<Login>($"EMAIL = '{email}' AND SENHA = '{senha}'");
        }
    }
}
