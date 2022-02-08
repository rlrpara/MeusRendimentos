using MeusRendimentos.Domain.Enumerables;
using System.Data;

namespace MeusRendimentos.Domain.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection Conexao();
    }
}
