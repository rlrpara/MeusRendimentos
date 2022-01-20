using Dapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Infra.Data.Context;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Text;

namespace MeusRendimentos.Infra.Database
{
    public static class DatabaseConfiguration
    {
        #region Métodos Privados
        private static string ObterNomeBanco()
            => Environment.GetEnvironmentVariable("MYSQL_DATABASE");
        private static string ObterProcedureDropConstraint(string nomeBanco)
        {
            var sqlComando = new StringBuilder();

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

            return sqlComando.ToString();
        }
        private static string ObterSqlCriarBanco(string nomeBanco)
        {
            var sqlComando = new StringBuilder();

            sqlComando.AppendLine($"CREATE DATABASE {nomeBanco}");
            sqlComando.AppendLine($"CHARACTER SET utf8");
            sqlComando.AppendLine($"COLLATE utf8_general_ci;");

            return sqlComando.ToString();
        }
        private static bool ExisteBanco(MySqlConnection conexao, string nomeBanco)
            => conexao.Query<string>($"SHOW DATABASES LIKE '{nomeBanco}';").ToList().Count > 0;
        private static void Criar(MySqlConnection conexao, string sqlCondicao)
                    => conexao.Execute(sqlCondicao);
        private static bool ExisteDados<T>(MySqlConnection conexao) where T : class
            => conexao.QueryFirstOrDefault<int>($"SELECT COUNT(*) AS Total FROM {GeradorDapper.ObterNomeTabela<T>()};") > 0;
        private static bool ServidorAtivo()
        {
            try
            {
                using MySqlConnection conexao = (MySqlConnection)ConnectionConfiguration.ObterConexao();
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
                //Verificar se o mysql está funcionando
                if (ServidorAtivo())
                {
                    var nomeBanco = ObterNomeBanco();
                    using MySqlConnection conexao = (MySqlConnection)ConnectionConfiguration.ObterConexao();

                    //Criar banco
                    if (!ExisteBanco(conexao, nomeBanco))
                        Criar(conexao, ObterSqlCriarBanco(nomeBanco));

                    //Criar tabelas
                    Criar(conexao, ObterProcedureDropConstraint(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Usuario>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Tipo>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Mes>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Cartao>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Categoria>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Despesa>(nomeBanco));
                    Criar(conexao, GeradorDapper.CriarTabela<Ganho>(nomeBanco));

                    //Criar procedures
                    Criar(conexao, GeradorDapper.GerarProcedureAddIfColumnNotExists(nomeBanco));

                    //Adicionar registros base
                    if (!ExisteDados<Usuario>(conexao))
                        Criar(conexao, GeradorDapper.InserirDadosPadroes<Usuario>());
                    if (!ExisteDados<Tipo>(conexao))
                        Criar(conexao, GeradorDapper.InserirDadosPadroes<Tipo>());


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
