using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MeusRendimentos.Infra.Data.Context
{
    public class ConnectionConfiguration
    {
        #region Métodos Privados
        private static ParametrosConexao ObterParametrosConexao() => new ParametrosConexao()
        {
            ServidorOnline = Environment.GetEnvironmentVariable("MYSQL_SERVER_ONLINE"),
            ServidorLocal = Environment.GetEnvironmentVariable("MYSQL_SERVER_LOCAL"),
            TipoAcesso = Convert.ToInt32(Environment.GetEnvironmentVariable("MYSQL_TIPO")),
            Usuario = Environment.GetEnvironmentVariable("MYSQL_USER"),
            Senha = Environment.GetEnvironmentVariable("MYSQL_PASSWORD"),
            NomeBanco = Environment.GetEnvironmentVariable("MYSQL_DATABASE"),
            Porta = Convert.ToInt32(Environment.GetEnvironmentVariable("MYSQL_PORT")),
        };
        private static string ObterStringConexao()
        {
            ParametrosConexao conn = ObterParametrosConexao();

            return $"Server={(conn.TipoAcesso == 1 ? conn.ServidorOnline : conn.ServidorLocal)}; User Id={conn.Usuario}; Password={conn.Senha}; Allow User Variables=True";
        }
        #endregion

        #region Métodos Públicos
        public static IDbConnection ObterConexao() => Inicia(new MySqlConnection(ObterStringConexao()));
        public static IDbConnection Inicia(IDbConnection conexao)
        {
            if(conexao != null && conexao.State == ConnectionState.Open)
                conexao.Close();
            else if(conexao != null && conexao.State == ConnectionState.Closed)
                conexao.Open();

            return conexao;
        }
        #endregion
    }
}
