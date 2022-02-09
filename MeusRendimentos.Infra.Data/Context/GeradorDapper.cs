using MeusRendimentos.Domain.Entities.Base;
using MeusRendimentos.Domain.Enumerables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MeusRendimentos.Infra.Data.Context
{
    public static class GeradorDapper
    {
        #region [Propriedades Privadas]
        private readonly static string _nomeBanco = Environment.GetEnvironmentVariable("DATABASE");
        private readonly static TipoBanco _tipoBanco = (TipoBanco)Convert.ToInt32(Environment.GetEnvironmentVariable("TIPO_BANCO"));
        #endregion

        #region Métodos Privados
        public static string ObterColunasGrid<T>(IEnumerable<T> list) where T : class
        {
            string chavePrimaria = string.Empty;
            List<string> campos = new List<string>();

            foreach (var lista in list)
            {
                foreach (var item in lista.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(p => ((ColumnAttribute)p.GetCustomAttributes(typeof(ColumnAttribute)).FirstOrDefault()).Order))
                {
                    var opcoesBase = (OpcoesBaseAttribute)item.GetCustomAttribute(typeof(OpcoesBaseAttribute));
                    if (opcoesBase != null && (opcoesBase.UsarParaBuscar && item.GetCustomAttribute<ColumnAttribute>().Name != ""))
                            campos.Add($"{item.GetCustomAttribute<ColumnAttribute>().Name}|{item.Name}|{opcoesBase.TamanhoColunaGrid}|{opcoesBase.UsarNaGrid}");
                }
                break;
            }

            var sqlPesquisa = new StringBuilder().AppendLine($"{(string.Join($";", campos.ToArray()))}");

            return sqlPesquisa.ToString();
        }
        public static string ObterDadosGrid<T>(string sqlWhere) where T : class
        {
            string chavePrimaria = string.Empty;
            List<string> campos = new List<string>();

            foreach (var item in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(p => ((ColumnAttribute)p.GetCustomAttributes(typeof(ColumnAttribute)).FirstOrDefault()).Order))
            {
                var opcoesBase = (OpcoesBaseAttribute)item.GetCustomAttribute(typeof(OpcoesBaseAttribute));
                if (opcoesBase != null)
                {
                    var tipoCampo = item.PropertyType.Name;

                    if (opcoesBase.ChavePrimaria)
                        chavePrimaria = item.GetCustomAttribute<ColumnAttribute>().Name;

                    if (opcoesBase.UsarParaBuscar && item.GetCustomAttribute<ColumnAttribute>().Name != "" && opcoesBase.UsarNaGrid)
                        campos.Add($"{item.GetCustomAttribute<ColumnAttribute>().Name} AS {item.Name}");
                }
            }

            var sqlPesquisa = new StringBuilder();

            sqlPesquisa.AppendLine($"USE {_nomeBanco};");
            sqlPesquisa.AppendLine($"SELECT {(string.Join($",{Environment.NewLine}       ", campos.ToArray()))}");
            sqlPesquisa.AppendLine($"  FROM {ObterNomeTabela<T>()}");
            sqlPesquisa.AppendLine($" WHERE {chavePrimaria} IS NOT NULL");
            sqlPesquisa.AppendLine(sqlWhere);

            return sqlPesquisa.ToString();
        }
        private static string TipoPropriedade(PropertyInfo item)
        {
            return item.PropertyType.Name switch
            {
                "Int32" => _tipoBanco == TipoBanco.MySql ? "int(11) DEFAULT NULL": "int NOT NULL DEFAULT 1",
                "Int64" => "bigint DEFAULT NULL",
                "Double" => "decimal(18,2)",
                "Single" => "float",
                "DateTime" => "datetime DEFAULT CURRENT_TIMESTAMP",
                "Boolean" => _tipoBanco == TipoBanco.MySql ? "tinyint(1) NOT NULL DEFAULT 1" : "int NOT NULL DEFAULT 1",
                "Nullable`1" => ObterParaTipoNulo(item.PropertyType.FullName),
                _ => "varchar(255) NULL",
            };
        }
        private static string ObterParaTipoNulo(string fullName)
        {
            if (fullName.Contains("Int32"))
                return "int(11) DEFAULT NULL";
            else if (fullName.Contains("DateTime"))
                return "datetime DEFAULT NULL";
            else
                return "varchar(255) NULL";
        }
        #endregion

        #region Métodos Públicos
        public static string InserirDadosPadroes<T>() where T : class
        {
            var nomeTabela = ObterNomeTabela<T>();

            var sqlInsert = new StringBuilder();

            switch (nomeTabela.ToLower())
            {
                case "usuario":
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (           NOME,             EMAIL, SENHA, FUNCAO_ID)");
                    sqlInsert.AppendLine($"                            VALUES ('Administrador', 'admin@email.com', '123',         1)");
                    break;
                case "tipo":
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} ( DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (   'Teste')");
                    break;
                case "mes":
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (   'JANEIRO');");
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES ( 'FEVEREIRO');");
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (     'MARÇO');");
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (     'ABRIL');");
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (      'MAIO');");
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (     'JUNHO');");
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (     'JULHO');");
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (    'AGOSTO');");
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (  'SETEMBRO');");
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (   'OUTUBRO');");
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (  'NOVEMBRO');");
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (   DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES (  'DEZEMBRO');");
                    break;
                case "funcao":
                    sqlInsert.AppendLine($"INSERT INTO {nomeTabela.ToLower()} (           NOME,                  DESCRICAO)");
                    sqlInsert.AppendLine($"                            VALUES ('Administrador', 'Administrador do Sistema')");
                    break;
                default:
                    break;
            }

            return sqlInsert.ToString();
        }
        public static string ObterNomeTabela<T>() where T : class
        {
            dynamic tableattr = typeof(T).GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");

            return (tableattr != null ? tableattr.Name.ToLower() : "");
        }
        public static string RetornaSelect<T>(int? id = null) where T : class
        {
            string chavePrimaria = string.Empty;
            List<string> campos = new List<string>();

            foreach (PropertyInfo item in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(p => ((ColumnAttribute)p.GetCustomAttributes(typeof(ColumnAttribute)).FirstOrDefault()).Order))
            {
                var opcoesBase = (OpcoesBaseAttribute)item.GetCustomAttribute(typeof(OpcoesBaseAttribute));
                if (opcoesBase != null)
                {
                    var tipoCampo = item.PropertyType.Name;

                    if (opcoesBase.ChavePrimaria)
                        chavePrimaria = item.GetCustomAttribute<ColumnAttribute>().Name;

                    if (opcoesBase.UsarParaBuscar && item.GetCustomAttribute<ColumnAttribute>().Name != "")
                        campos.Add($"{item.GetCustomAttribute<ColumnAttribute>().Name} AS {item.Name}");
                }
            }

            var sqlPesquisa = new StringBuilder();

            sqlPesquisa.AppendLine($"USE {_nomeBanco};");
            sqlPesquisa.AppendLine($"SELECT {(string.Join($",{Environment.NewLine}       ", campos.ToArray()))}");
            sqlPesquisa.AppendLine($"  FROM {ObterNomeTabela<T>()}");
            sqlPesquisa.AppendLine($" WHERE {chavePrimaria} IS NOT NULL");

            if (id != null)
                sqlPesquisa.AppendLine($"   AND {chavePrimaria} = {id}");

            return sqlPesquisa.ToString();
        }
        public static string RetornaInsert<T>(T entidade) where T : class
        {
            List<string> campos = new List<string>();
            List<string> valores = new List<string>();

            foreach (PropertyInfo item in entidade.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(p => ((ColumnAttribute)p.GetCustomAttributes(typeof(ColumnAttribute)).FirstOrDefault()).Order))
            {
                var tipoCampo = item.PropertyType;
                var opcoesBase = (OpcoesBaseAttribute)item.GetCustomAttribute(typeof(OpcoesBaseAttribute));

                if (opcoesBase != null && opcoesBase.UsarNoBancoDeDados && !opcoesBase.ChavePrimaria)
                {
                    var valor = item.GetValue(entidade);

                    if (valor != null)
                    {
                        campos.Add(item.GetCustomAttribute<ColumnAttribute>().Name);

                        if (tipoCampo.Name.ToLower().Contains("string"))
                            valores.Add($"'{valor}'");

                        else if (tipoCampo.Name.ToLower().Contains("datetime"))
                            valores.Add($"'{Convert.ToDateTime(valor):yyyy-MM-dd HH:mm:ss}'");

                        else if (tipoCampo.Name.ToLower().Contains("nullable`1"))
                            if (tipoCampo.ToString().ToLower().Contains("datetime"))
                                valores.Add($"'{Convert.ToDateTime(valor):yyyy-MM-dd HH:mm:ss}'");

                            else if (tipoCampo.ToString().ToLower().Contains("int32"))
                                valores.Add($"{valor}");

                            else
                                valores.Add($"'{valor}'");

                        else
                            valores.Add($"{valor}");
                    }
                }
            }

            var sqlInsert = new StringBuilder();

            sqlInsert.Append($"USE {_nomeBanco};");
            sqlInsert.AppendLine($"INSERT INTO {ObterNomeTabela<T>()} ({string.Join(", ", campos.ToArray())})");
            sqlInsert.AppendLine($"            VALUES ({string.Join(", ", valores.ToArray())});");

            return sqlInsert.ToString();
        }
        public static string GerarProcedureIfColumnNotExists(string nomeBanco)
        {
            var sqlPesquisa = new StringBuilder();

            switch (_tipoBanco)
            {
                case TipoBanco.MySql:
                    sqlPesquisa.AppendLine($"USE {nomeBanco};");
                    sqlPesquisa.AppendLine($"DROP PROCEDURE IF EXISTS AddIfColumnNotExists; ");
                    sqlPesquisa.AppendLine($"DROP FUNCTION IF EXISTS IfColumnExists; ");
                    sqlPesquisa.AppendLine($"CREATE FUNCTION IfColumnExists (table_name_IN VARCHAR(100), field_name_IN VARCHAR(100)) ");
                    sqlPesquisa.AppendLine($"RETURNS INT");
                    sqlPesquisa.AppendLine($"RETURN (");
                    sqlPesquisa.AppendLine($"    SELECT COUNT(COLUMN_NAME) ");
                    sqlPesquisa.AppendLine($"    FROM INFORMATION_SCHEMA.columns ");
                    sqlPesquisa.AppendLine($"    WHERE TABLE_SCHEMA = DATABASE() ");
                    sqlPesquisa.AppendLine($"    AND TABLE_NAME = table_name_IN ");
                    sqlPesquisa.AppendLine($"    AND COLUMN_NAME = field_name_IN");
                    sqlPesquisa.AppendLine($");");
                    sqlPesquisa.AppendLine($"CREATE PROCEDURE AddIfColumnNotExists (");
                    sqlPesquisa.AppendLine($"    IN table_name_IN VARCHAR(100)");
                    sqlPesquisa.AppendLine($"    , IN field_name_IN VARCHAR(100)");
                    sqlPesquisa.AppendLine($"    , IN field_definition_IN VARCHAR(100)");
                    sqlPesquisa.AppendLine($")");
                    sqlPesquisa.AppendLine($"BEGIN");
                    sqlPesquisa.AppendLine($"    SET @isFieldThere = IfColumnExists(table_name_IN, field_name_IN);");
                    sqlPesquisa.AppendLine($"    IF (@isFieldThere = 0) THEN");
                    sqlPesquisa.AppendLine($"        SET @ddl = CONCAT('ALTER TABLE ', table_name_IN);");
                    sqlPesquisa.AppendLine($"        SET @ddl = CONCAT(@ddl, ' ', 'ADD COLUMN') ;");
                    sqlPesquisa.AppendLine($"        SET @ddl = CONCAT(@ddl, ' ', field_name_IN);");
                    sqlPesquisa.AppendLine($"        SET @ddl = CONCAT(@ddl, ' ', field_definition_IN);");
                    sqlPesquisa.AppendLine($"        PREPARE stmt FROM @ddl;");
                    sqlPesquisa.AppendLine($"        EXECUTE stmt;");
                    sqlPesquisa.AppendLine($"        DEALLOCATE PREPARE stmt;");
                    sqlPesquisa.AppendLine($"    END IF;");
                    sqlPesquisa.AppendLine($"END;");
                    break;
                case TipoBanco.SqlServer:
                    sqlPesquisa.AppendLine($"");
                    break;
                case TipoBanco.Firebird:
                    sqlPesquisa.AppendLine($"");
                    break;
                case TipoBanco.Postgresql:
                    sqlPesquisa.AppendLine($"");
                    break;
                case TipoBanco.Sqlite:
                    sqlPesquisa.AppendLine($"");
                    break;
                default:
                    break;
            }
            

            return sqlPesquisa.ToString();
        }
        public static string RetornaUpdate<T>(int id, T entidade) where T : class
        {
            List<string> condicao = new List<string>();
            string campoChave = string.Empty;

            foreach (PropertyInfo item in entidade.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public).OrderBy(p => ((ColumnAttribute)p.GetCustomAttributes(typeof(ColumnAttribute)).FirstOrDefault()).Order))
            {
                OpcoesBaseAttribute opcoesBase = (OpcoesBaseAttribute)item.GetCustomAttribute(typeof(OpcoesBaseAttribute));

                if (opcoesBase != null && opcoesBase.UsarNoBancoDeDados && !opcoesBase.ChavePrimaria)
                {
                    var valor = item.GetValue(entidade);
                    var campo = item.GetCustomAttribute<ColumnAttribute>().Name;
                    var tipoCampo = item.PropertyType.Name.ToLower();

                    if (opcoesBase.ChavePrimaria)
                        campoChave = item.GetCustomAttribute<ColumnAttribute>().Name;

                    if (valor != null)
                    {
                        if (tipoCampo.Contains("string"))
                            condicao.Add($"{campo} = '{valor}'");

                        else if (tipoCampo.Contains("datetime"))
                            condicao.Add($"{campo} = '{Convert.ToDateTime(valor):yyyy-MM-dd HH:mm:ss}'");

                        else if (tipoCampo.Contains("nullable`1"))
                            if (tipoCampo.ToString().ToLower().Contains("datetime"))
                                condicao.Add($"{campo} = '{Convert.ToDateTime(valor):yyyy-MM-dd HH:mm:ss}'");

                            else if (tipoCampo.ToString().ToLower().Contains("int32"))
                                condicao.Add($"{campo} = {valor}");

                            else
                                condicao.Add($"{campo} = '{valor}'");
                        else
                            condicao.Add($"{campo} = {valor}");
                    }
                }
                else if (opcoesBase != null && opcoesBase.ChavePrimaria)
                {
                    campoChave = item.GetCustomAttribute<ColumnAttribute>().Name;
                }
            }

            var sqlAtualizar = new StringBuilder();

            sqlAtualizar.AppendLine($"USE {_nomeBanco};");
            sqlAtualizar.AppendLine($"UPDATE {ObterNomeTabela<T>()}");
            sqlAtualizar.AppendLine($"   SET {(string.Join($",{Environment.NewLine}       ", condicao.ToArray()))}");
            sqlAtualizar.AppendLine($" WHERE {campoChave} = {id}");

            return sqlAtualizar.ToString();
        }
        public static string RetornaDelete<T>(int id) where T : class
        {
            string campoChave = string.Empty;

            foreach (PropertyInfo item in typeof(T).GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public).OrderBy(p => ((ColumnAttribute)p.GetCustomAttributes(typeof(ColumnAttribute)).FirstOrDefault()).Order))
            {
                OpcoesBaseAttribute opcoesBase = (OpcoesBaseAttribute)item.GetCustomAttribute(typeof(OpcoesBaseAttribute));

                if (opcoesBase != null && opcoesBase.UsarNoBancoDeDados && opcoesBase.ChavePrimaria)
                    campoChave = item.GetCustomAttribute<ColumnAttribute>().Name;
            }

            var sqlDelete = new StringBuilder();

            sqlDelete.AppendLine($"USE {_nomeBanco};");
            sqlDelete.AppendLine($"DELETE FROM {ObterNomeTabela<T>()}");
            sqlDelete.AppendLine($" WHERE {campoChave} = {id}");

            return sqlDelete.ToString();
        }
        public static string CriarTabela<T>(string nomeBanco) where T : class
        {
            string chavePrimaria = string.Empty;
            List<string> campos = new List<string>();
            StringBuilder sqlConstraint = new StringBuilder();

            foreach (PropertyInfo item in typeof(T).GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public))
            {
                var opcoesBase = (OpcoesBaseAttribute)item.GetCustomAttribute(typeof(OpcoesBaseAttribute));

                if (opcoesBase != null)
                {
                    var nomeCampo = item.GetCustomAttribute<ColumnAttribute>().Name;

                    if (opcoesBase.UsarParaBuscar)
                    {
                        if (opcoesBase.ChavePrimaria)
                            chavePrimaria = $"{nomeCampo}";

                        else if (nomeCampo != "")
                            campos.Add($"{nomeCampo} {TipoPropriedade(item)}");
                    }

                    if (!string.IsNullOrEmpty(opcoesBase.ChaveEstrangeira))
                    {
                        string tabelaChaveEstrangeira = $"{opcoesBase.ChaveEstrangeira.ToLower()}";
                        string campoChaveEstrangeira = $"{nomeCampo}";
                        string nomeChave = $"FK_{ObterNomeTabela<T>()}_{campoChaveEstrangeira}".ToUpper();
                        switch (_tipoBanco)
                        {
                            case TipoBanco.MySql:
                                sqlConstraint.AppendLine($"CALL PROC_DROP_FOREIGN_KEY('{ObterNomeTabela<T>()}', '{nomeChave}');");
                                sqlConstraint.AppendLine($"ALTER TABLE {nomeBanco}.{ObterNomeTabela<T>()}");
                                sqlConstraint.AppendLine($"ADD CONSTRAINT {nomeChave} FOREIGN KEY ({campoChaveEstrangeira})");
                                sqlConstraint.AppendLine($"REFERENCES {nomeBanco}.{tabelaChaveEstrangeira} (ID) ON DELETE NO ACTION ON UPDATE NO ACTION;{Environment.NewLine}");
                                break;
                            case TipoBanco.SqlServer:
                                break;
                            case TipoBanco.Firebird:
                                break;
                            case TipoBanco.Postgresql:
                                break;
                            case TipoBanco.Sqlite:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            var sqlPesquisa = new StringBuilder();

            switch (_tipoBanco)
            {
                case TipoBanco.MySql:
                    sqlPesquisa.AppendLine($"USE {nomeBanco};");
                    sqlPesquisa.AppendLine($"CREATE TABLE IF NOT EXISTS {nomeBanco}.{ObterNomeTabela<T>()} (");
                    sqlPesquisa.AppendLine($"  {chavePrimaria} int(11) NOT NULL AUTO_INCREMENT,");
                    sqlPesquisa.AppendLine($"  {string.Join($",{Environment.NewLine}   ", campos.ToArray())},");
                    sqlPesquisa.AppendLine($"  PRIMARY KEY ({chavePrimaria})");
                    sqlPesquisa.AppendLine($")");
                    sqlPesquisa.AppendLine($"ENGINE = INNODB,");
                    sqlPesquisa.AppendLine($"CHARACTER SET utf8,");
                    sqlPesquisa.AppendLine($"COLLATE utf8_general_ci;{Environment.NewLine}");
                    if (!string.IsNullOrEmpty(sqlConstraint.ToString()))
                        sqlPesquisa.AppendLine(sqlConstraint.ToString());
                    break;
                case TipoBanco.SqlServer:
                    sqlPesquisa.AppendLine($"USE {nomeBanco};");
                    sqlPesquisa.AppendLine($"IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{ObterNomeTabela<T>()}')");
                    sqlPesquisa.AppendLine($"BEGIN");
                    sqlPesquisa.AppendLine($"   CREATE TABLE {ObterNomeTabela<T>()}(");
                    sqlPesquisa.AppendLine($"        {chavePrimaria} int IDENTITY(1,1) NOT NULL,");
                    sqlPesquisa.AppendLine($"        {string.Join($",{Environment.NewLine}   ", campos.ToArray())},");
                    sqlPesquisa.AppendLine($"  CONSTRAINT [PK_{ObterNomeTabela<T>()}] PRIMARY KEY CLUSTERED ");
                    sqlPesquisa.AppendLine($"(");
                    sqlPesquisa.AppendLine($"   {chavePrimaria} ASC");
                    sqlPesquisa.AppendLine($")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");
                    sqlPesquisa.AppendLine($") ON [PRIMARY]");
                    sqlPesquisa.AppendLine($"END");
                    break;
                case TipoBanco.Firebird:
                    break;
                case TipoBanco.Postgresql:
                    break;
                case TipoBanco.Sqlite:
                    sqlPesquisa.AppendLine($"CREATE TABLE IF NOT EXISTS {ObterNomeTabela<T>()} (");
                    sqlPesquisa.AppendLine($"  {chavePrimaria} INT,");
                    sqlPesquisa.AppendLine($"  {string.Join($",{Environment.NewLine}   ", campos.ToArray())},");
                    sqlPesquisa.AppendLine($"  PRIMARY KEY ({chavePrimaria})");
                    sqlPesquisa.AppendLine($")");
                    break;
                default:
                    break;
            }

            return sqlPesquisa.ToString();
        }
        #endregion
    }
}
