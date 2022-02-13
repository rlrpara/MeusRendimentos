using Dapper;
using MeusRendimentos.Domain.Enumerables;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MeusRendimentos.Infra.Data.Repositories
{
    public class BaseRepository : IDisposable, IBaseRepository
    {
        #region [Propriedades Privadas]
        protected readonly IDbConnection _conexao;
        private readonly string _nomeBanco;
        #endregion

        #region [Construtores]
        public BaseRepository()
        {
            _nomeBanco = Environment.GetEnvironmentVariable("DATABASE");
            _conexao = ConnectionConfiguration.ObterConexao(ObterTipoBanco());
        }
        #endregion

        #region [Métodos Privados]
        private static string ObterNomeTabela<T>()
        {
            return TableNameMapper(typeof(T));
        }
        private static string TableNameMapper(Type type)
        {
            dynamic tableattr = type.GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");
            return (tableattr != null ? tableattr.Name : string.Empty);
        }
        private TipoBanco ObterTipoBanco()
        {
            return (TipoBanco)Convert.ToInt32(Environment.GetEnvironmentVariable("TIPO_BANCO"));
        }
        #endregion

        #region [Métodos Públicos]
        public int Adicionar<T>(T entidade) where T : class
        {
            return _conexao.Execute(GeradorDapper.RetornaInsert(entidade));
        }
        public int Atualizar<T>(int id, T entidade) where T : class
        {
            return _conexao.Execute(GeradorDapper.RetornaUpdate(id, entidade));
        }
        public void AtualizarPorQuery<T>(string query)
        {
            _conexao.Query<T>(query, commandTimeout: 80000000, commandType: CommandType.Text);
        }
        public T BuscarPorId<T>(int id) where T : class
        {
            return _conexao.QueryFirstOrDefault<T>($"{GeradorDapper.RetornaSelect<T>(id)}", commandTimeout: 80000000, commandType: CommandType.Text);
        }

        public T BuscarPorQuery<T>(string query) where T : class
        {
            return _conexao.QueryFirstOrDefault<T>(query, commandTimeout: 80000000, commandType: CommandType.Text);
        }

        public T BuscarPorQueryGerador<T>(string sqlWhere = null) where T : class
        {
            StringBuilder sqlPesquisa = new StringBuilder()
                .AppendLine($"{GeradorDapper.RetornaSelect<T>()}");

            if (!string.IsNullOrEmpty(sqlWhere)) sqlPesquisa.Append($"AND {sqlWhere}");

            return _conexao.Query<T>(sqlPesquisa.ToString(), commandTimeout: 80000000, commandType: CommandType.Text).FirstOrDefault();
        }

        public IEnumerable<T> BuscarTodosPorQuery<T>(string query = null) where T : class
        {
            StringBuilder sqlPesquisa = new StringBuilder();

            if (string.IsNullOrEmpty(query))
                sqlPesquisa.AppendLine($"{GeradorDapper.RetornaSelect<T>()}");
            else
            {
                sqlPesquisa.AppendLine($"USE {_nomeBanco};");
                sqlPesquisa.AppendLine($"{query.Trim()}");
            }

            return _conexao.Query<T>(sqlPesquisa.ToString(), commandTimeout: 80000000, commandType: CommandType.Text);
        }

        public IEnumerable<T> BuscarTodosPorQueryGerador<T>(string sqlWhere = null) where T : class
        {
            StringBuilder sqlPesquisa = new StringBuilder().Append($"{GeradorDapper.RetornaSelect<T>()}");
            if (!string.IsNullOrEmpty(sqlWhere)) sqlPesquisa.Append($"AND {sqlWhere}");

            return _conexao.Query<T>(sqlPesquisa.ToString(), commandTimeout: 80000000, commandType: CommandType.Text).ToList();
        }

        public int Excluir<T>(int id) where T : class
        {
            return _conexao.Execute($"{GeradorDapper.RetornaDelete<T>(id)}");
        }
        public List<T> Query<T>(string where) where T : class
        {
            return _conexao.Query<T>(where, commandTimeout: 80000000, commandType: CommandType.Text).ToList();
        }
        public int ObterUltimoRegistro<T>() where T : class
        {
            return _conexao.QueryFirst<int>($"SELECT ID FROM {ObterNomeTabela<T>()} ORDER BY ID DESC LIMIT 1");
        }
        public void Dispose()
        {
            _conexao.Close();
            _conexao.Dispose();
        }
        #endregion
    }
}
