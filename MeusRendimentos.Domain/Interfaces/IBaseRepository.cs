﻿using System;
using System.Collections.Generic;

namespace MeusRendimentos.Domain.Interfaces
{
    public interface IBaseRepository : IDisposable
    {
        List<TEntity> Query<TEntity>(string where) where TEntity : class;
        TEntity BuscarPorId<TEntity>(int id) where TEntity : class;
        TEntity BuscarPorQuery<TEntity>(string query) where TEntity : class;
        TEntity BuscarPorQueryGerador<TEntity>(string sqlWhere = null) where TEntity : class;
        IEnumerable<TEntity> BuscarTodosPorQuery<TEntity>(string query = null) where TEntity : class;
        IEnumerable<TEntity> BuscarTodosPorQueryGerador<TEntity>(string sqlWhere = null) where TEntity : class;
        int Adicionar<TEntity>(TEntity entidade) where TEntity : class;
        int Atualizar<TEntity>(int id, TEntity entidade) where TEntity : class;
        int Excluir<TEntity>(int id) where TEntity : class;
        int ObterUltimoRegistro<TEntity>() where TEntity : class;
    }
}
