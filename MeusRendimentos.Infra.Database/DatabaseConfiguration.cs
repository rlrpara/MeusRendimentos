using Dapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Enumerables;
using MeusRendimentos.Infra.Data.Context;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace MeusRendimentos.Infra.Database
{
    public static class DatabaseConfiguration
    {
        #region Métodos Privados
        private static TipoBanco _tipoBanco;
        private static string ObterNomeBanco()
            => Environment.GetEnvironmentVariable("DATABASE");
        private static string ObterProcedureDropConstraint(string nomeBanco)
        {
            var sqlComando = new StringBuilder();

            switch (_tipoBanco)
            {
                case TipoBanco.MySql:
                    sqlComando.AppendLine($"USE {nomeBanco};");
                    sqlComando.AppendLine($"DROP PROCEDURE IF EXISTS PROC_DROP_FOREIGN_KEY;");
                    sqlComando.AppendLine($"CREATE PROCEDURE PROC_DROP_FOREIGN_KEY(IN tableName VARCHAR(64), IN constraintName VARCHAR(64))");
                    sqlComando.AppendLine($"BEGIN");
                    sqlComando.AppendLine($"    IF EXISTS(");
                    sqlComando.AppendLine($"        SELECT * FROM information_schema.table_constraints");
                    sqlComando.AppendLine($"        WHERE ");
                    sqlComando.AppendLine($"            table_schema    = DATABASE()     AND");
                    sqlComando.AppendLine($"            table_name      = tableName      AND");
                    sqlComando.AppendLine($"            constraint_name = constraintName AND");
                    sqlComando.AppendLine($"            constraint_type = 'FOREIGN KEY')");
                    sqlComando.AppendLine($"    THEN");
                    sqlComando.AppendLine($"        SET @query = CONCAT('ALTER TABLE ', tableName, ' DROP FOREIGN KEY ', constraintName, ';');");
                    sqlComando.AppendLine($"        PREPARE stmt FROM @query; ");
                    sqlComando.AppendLine($"        EXECUTE stmt; ");
                    sqlComando.AppendLine($"        DEALLOCATE PREPARE stmt; ");
                    sqlComando.AppendLine($"    END IF; ");
                    sqlComando.AppendLine($"END");
                    break;
                case TipoBanco.SqlServer:
                    sqlComando.AppendLine($"");
                    break;
                case TipoBanco.Firebird:
                    break;
                case TipoBanco.Postgresql:
                    break;
                default:
                    break;
            }

            return sqlComando.ToString();
        }
        private static string ObterSqlCriarBanco(string nomeBanco)
        {
            var sqlComando = new StringBuilder();

            switch (_tipoBanco)
            {
                case TipoBanco.MySql:
                    sqlComando.AppendLine($"CREATE DATABASE {nomeBanco}");
                    sqlComando.AppendLine($"CHARACTER SET utf8");
                    sqlComando.AppendLine($"COLLATE utf8_general_ci;");
                    break;
                case TipoBanco.SqlServer:
                    sqlComando.AppendLine($"CREATE DATABASE {nomeBanco};");
                    break;
                case TipoBanco.Firebird:
                    break;
                case TipoBanco.Postgresql:
                    break;
                default:
                    break;
            }
            

            return sqlComando.ToString();
        }
        private static bool ExisteBanco(IDbConnection conexao, string nomeBanco)
        {
            var sqlPesquisa = new StringBuilder();
            switch (_tipoBanco)
            {
                case TipoBanco.MySql:
                    sqlPesquisa.AppendLine($"SHOW DATABASES LIKE '{nomeBanco}';");
                    break;
                case TipoBanco.SqlServer:
                    sqlPesquisa.AppendLine($"SELECT NAME");
                    sqlPesquisa.AppendLine($"  FROM MASTER.DBO.SYSDATABASES");
                    sqlPesquisa.AppendLine($"WHERE NAME = N'{nomeBanco}'");
                    break;
                case TipoBanco.Firebird:
                    break;
                case TipoBanco.Postgresql:
                    break;
                default:
                    break;
            }
            return conexao.Query<string>(sqlPesquisa.ToString()).ToList().Count > 0;
        }
        private static void Criar(IDbConnection conexao, string sqlCondicao)
                    => conexao.Execute(sqlCondicao);
        private static bool ExisteDados<T>(IDbConnection conexao) where T : class
            => conexao.QueryFirstOrDefault<int>($"SELECT COUNT(*) AS Total FROM {GeradorDapper.ObterNomeTabela<T>()};") > 0;
        private static bool ServidorAtivo()
        {
            try
            {
                _tipoBanco = (TipoBanco)Convert.ToInt32(Environment.GetEnvironmentVariable("TIPO_BANCO")); ;
                using var conexao = ConnectionConfiguration.ObterConexao(_tipoBanco);
                ExisteBanco(conexao, ObterNomeBanco());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Métodos Públicos
        public static void GerenciarBanco()
        {
            try
            {
                if (ServidorAtivo())
                {
                    var nomeBanco = ObterNomeBanco();
                    using var conexao = ConnectionConfiguration.ObterConexao(_tipoBanco);

                    //Criar banco
                    if (!ExisteBanco(conexao, nomeBanco))
                        Criar(conexao, ObterSqlCriarBanco(nomeBanco));

                    //Criar tabelas
                    Criar(conexao, ObterProcedureDropConstraint(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Funcao>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Usuario>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Tipo>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Mes>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Cartao>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Categoria>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Despesa>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Ganho>(nomeBanco));

                    //Criar procedures
                    Criar(conexao, GeradorDapper.GerarProcedureIfColumnNotExists(nomeBanco));

                    //Adicionar registros base
                    if (!ExisteDados<Funcao>(conexao))
                        Criar(conexao, GeradorDapper.InserirDadosPadroes<Funcao>());
                    if (!ExisteDados<Usuario>(conexao))
                        Criar(conexao, GeradorDapper.InserirDadosPadroes<Usuario>());
                    if (!ExisteDados<Tipo>(conexao))
                        Criar(conexao, GeradorDapper.InserirDadosPadroes<Tipo>());
                    if (!ExisteDados<Mes>(conexao))
                        Criar(conexao, GeradorDapper.InserirDadosPadroes<Mes>());


                    //executar scripts da versao
                }
                else
                {
                    throw new Exception("Base de dados Offline.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
