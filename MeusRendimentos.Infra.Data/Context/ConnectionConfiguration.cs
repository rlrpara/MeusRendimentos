using MeusRendimentos.Domain.Enumerables;
using System.Data;

namespace MeusRendimentos.Infra.Data.Context
{
    public static class ConnectionConfiguration
    {
        #region [Métodos Privados]
        private static IDbConnection Inicia(IDbConnection conexao)
        {
            if (conexao != null)
            {
                if(conexao.State == ConnectionState.Open)
                    conexao.Close();
                if (conexao.State == ConnectionState.Closed)
                    conexao.Open();
            }

            return conexao;
        }
        #endregion

        #region Métodos Públicos
        public static IDbConnection ObterConexao(TipoBanco tipoBanco)
            => Inicia(new DeafultSqlConnectionFactory(tipoBanco).Conexao());
        #endregion
    }
}
