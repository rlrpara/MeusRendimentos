using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.Interfaces;
using System.Collections.Generic;

namespace MeusRendimentos.Services.Services
{
    public class BaseService : IBaseService
    {
        protected readonly IBaseRepository _baseRepository;

        public BaseService(IBaseRepository repositorio)
        {
            _baseRepository = repositorio;
        }

        public int Adicionar<T>(T entidade) where T : class
        {
            try
            {
                return _baseRepository.Adicionar(entidade);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public int Atualizar<T>(int id, T entidade) where T : class
        {
            try
            {
                return _baseRepository.Atualizar(id, entidade);
            }
            catch
            {
                return default(dynamic);
            }
        }
        public void AtualizarPorQuery<T>(string query)
        {
            _baseRepository.AtualizarPorQuery<T>(query);
        }
        public T BuscarPorId<T>(int id) where T : class
        {
            try
            {
                return _baseRepository.BuscarPorId<T>(id);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public T BuscarPorQuery<T>(string query) where T : class
        {
            try
            {
                return _baseRepository.BuscarPorQuery<T>(query);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public T BuscarPorQueryGerador<T>(string sqlWhere = null) where T : class
        {
            try
            {
                return _baseRepository.BuscarPorQueryGerador<T>(sqlWhere);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public IEnumerable<T> BuscarTodosPorQuery<T>(string query = null) where T : class
        {
            try
            {
                return _baseRepository.BuscarTodosPorQuery<T>(query);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public IEnumerable<T> BuscarTodosPorQueryGerador<T>(string sqlWhere = null) where T : class
        {
            try
            {
                return _baseRepository.BuscarTodosPorQueryGerador<T>(sqlWhere);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public int Excluir<T>(int id) where T : class
        {
            try
            {
                return _baseRepository.Excluir<T>(id);
            }
            catch
            {
                return default(dynamic);
            }
        }
        public List<T> Query<T>(string where) where T : class
        {
            return _baseRepository.Query<T>(where);
        }
        public int ObterUltimoRegistro<T>() where T : class
        {
            return _baseRepository.ObterUltimoRegistro<T>();
        }
        public void Dispose()
        {
            _baseRepository.Dispose();
        }

    }
}
