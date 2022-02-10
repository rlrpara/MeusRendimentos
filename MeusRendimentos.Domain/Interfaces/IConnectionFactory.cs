using System.Data;

namespace MeusRendimentos.Domain.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection Conexao(bool adicionaBanco = false);
    }
}
