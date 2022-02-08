using MeusRendimentos.Domain.Enumerables;
using MeusRendimentos.Domain.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MeusRendimentos.Infra.Data.Context
{
    public class DeafultSqlConnectionFactory : IConnectionFactory
    {
        #region [Propriedades Privadas]
        private readonly ParametrosConexao _conexao;
        private readonly TipoBanco _tipoBanco;
        #endregion

        #region [Métodos Privados]
        private static ParametrosConexao ObterParametrosConexao() => new ParametrosConexao()
        {
            ServidorOnline = Environment.GetEnvironmentVariable("SERVER_ONLINE"),
            ServidorLocal = Environment.GetEnvironmentVariable("SERVER_LOCAL"),
            TipoAcesso = Convert.ToInt32(Environment.GetEnvironmentVariable("TIPO")),
            Usuario = Environment.GetEnvironmentVariable("USER"),
            Senha = Environment.GetEnvironmentVariable("PASSWORD"),
            NomeBanco = Environment.GetEnvironmentVariable("DATABASE"),
            Porta = Convert.ToInt32(Environment.GetEnvironmentVariable("PORT")),
        };
        private SqlConnection ObtemStringConexaoSqlServer()
        {
            return new SqlConnection($"Server={(_conexao.TipoAcesso == 1 ? _conexao.ServidorOnline : _conexao.ServidorLocal)};User Id={_conexao.Usuario};Password={_conexao.Senha};Integrated Security=false;");
        }
        private MySqlConnection ObtemStringConexaoMySql()
        {
            return new MySqlConnection($"Server={(_conexao.TipoAcesso == 1 ? _conexao.ServidorOnline : _conexao.ServidorLocal)}; User Id={_conexao.Usuario}; Password={_conexao.Senha}; Allow User Variables=True");
        }
        #endregion

        #region [Construtor]
        public DeafultSqlConnectionFactory(TipoBanco tipoBanco)
        {
            _tipoBanco = tipoBanco;
            _conexao = ObterParametrosConexao();
        }
        #endregion

        #region [Métodos Públicos]
        public IDbConnection Conexao()
        {
            return _tipoBanco switch
            {
                TipoBanco.MySql => ObtemStringConexaoMySql(),
                TipoBanco.SqlServer => ObtemStringConexaoSqlServer(),
                TipoBanco.Firebird => null,
                TipoBanco.Postgresql => null,
                _ => null,
            };
        }
        #endregion
    }
}
