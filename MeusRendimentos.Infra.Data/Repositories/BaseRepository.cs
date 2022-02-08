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
        public int Adicionar<TEntity>(TEntity entidade) where TEntity : class
        {
            return _conexao.Execute(GeradorDapper.RetornaInsert(entidade));
        }

        public int Atualizar<TEntity>(int id, TEntity entidade) where TEntity : class
        {
            return _conexao.Execute(GeradorDapper.RetornaUpdate(id, entidade));
        }

        public TEntity BuscarPorId<TEntity>(int id) where TEntity : class
        {
            return _conexao.QueryFirstOrDefault<TEntity>($"{GeradorDapper.RetornaSelect<TEntity>(id)}", commandTimeout: 80000000, commandType: CommandType.Text);
        }

        public TEntity BuscarPorQuery<TEntity>(string query) where TEntity : class
        {
            return _conexao.QueryFirstOrDefault<TEntity>(query, commandTimeout: 80000000, commandType: CommandType.Text);
        }

        public TEntity BuscarPorQueryGerador<TEntity>(string sqlWhere = null) where TEntity : class
        {
            StringBuilder sqlPesquisa = new StringBuilder()
                .AppendLine($"{GeradorDapper.RetornaSelect<TEntity>()}");

            if (!string.IsNullOrEmpty(sqlWhere)) sqlPesquisa.Append($"AND {sqlWhere}");

            return _conexao.Query<TEntity>(sqlPesquisa.ToString(), commandTimeout: 80000000, commandType: CommandType.Text).FirstOrDefault();
        }

        public IEnumerable<TEntity> BuscarTodosPorQuery<TEntity>(string query = null) where TEntity : class
        {
            StringBuilder sqlPesquisa = new StringBuilder();

            if (string.IsNullOrEmpty(query))
                sqlPesquisa.AppendLine($"{GeradorDapper.RetornaSelect<TEntity>()}");
            else
            {
                sqlPesquisa.AppendLine($"USE {_nomeBanco};");
                sqlPesquisa.AppendLine($"{query.Trim()}");
            }

            return _conexao.Query<TEntity>(sqlPesquisa.ToString(), commandTimeout: 80000000, commandType: CommandType.Text);
        }

        public IEnumerable<TEntity> BuscarTodosPorQueryGerador<TEntity>(string sqlWhere = null) where TEntity : class
        {
            StringBuilder sqlPesquisa = new StringBuilder().Append($"{GeradorDapper.RetornaSelect<TEntity>()}");
            if (!string.IsNullOrEmpty(sqlWhere)) sqlPesquisa.Append($"AND {sqlWhere}");

            return _conexao.Query<TEntity>(sqlPesquisa.ToString(), commandTimeout: 80000000, commandType: CommandType.Text).ToList();
        }

        public int Excluir<TEntity>(int id) where TEntity : class
        {
            return _conexao.Execute($"{GeradorDapper.RetornaDelete<TEntity>(id)}");
        }

        public List<TEntity> Query<TEntity>(string where) where TEntity : class
        {
            return _conexao.Query<TEntity>(where, commandTimeout: 80000000, commandType: CommandType.Text).ToList();
        }

        public void Dispose()
        {
            _conexao.Close();
            _conexao.Dispose();
        }

        public int ObterUltimoRegistro<TEntity>() where TEntity : class
        {
            return _conexao.QueryFirst<int>($"SELECT ID FROM {ObterNomeTabela<TEntity>()} ORDER BY ID DESC LIMIT 1");
        }
        #endregion
    }
}
