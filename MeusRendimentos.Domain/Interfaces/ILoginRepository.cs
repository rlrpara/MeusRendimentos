using MeusRendimentos.Domain.Entities;

namespace MeusRendimentos.Domain.Interfaces
{
    public interface ILoginRepository : IBaseRepository
    {
        Login logar(string email, string senha);
    }
}
