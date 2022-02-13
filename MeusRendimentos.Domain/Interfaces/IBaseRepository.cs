using System;
using System.Collections.Generic;

namespace MeusRendimentos.Domain.Interfaces
{
    public interface IBaseRepository : IDisposable
    {
        List<T> Query<T>(string where) where T : class;
        T BuscarPorId<T>(int id) where T : class;
        T BuscarPorQuery<T>(string query) where T : class;
        T BuscarPorQueryGerador<T>(string sqlWhere = null) where T : class;
        IEnumerable<T> BuscarTodosPorQuery<T>(string query = null) where T : class;
        IEnumerable<T> BuscarTodosPorQueryGerador<T>(string sqlWhere = null) where T : class;
        int Adicionar<T>(T entidade) where T : class;
        int Atualizar<T>(int id, T entidade) where T : class;
        void AtualizarPorQuery<T>(string query);
        int Excluir<T>(int id) where T : class;
        int ObterUltimoRegistro<T>() where T : class;
    }
}
