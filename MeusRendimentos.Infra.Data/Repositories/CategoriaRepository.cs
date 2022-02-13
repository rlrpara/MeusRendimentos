using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;
using System.Text;

namespace MeusRendimentos.Infra.Data.Repositories
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        private readonly IBaseRepository _baseRepository;
        public CategoriaRepository(BaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public Categoria ObterCategoriaCompleta()
        {
            var sqlPesquisa = new StringBuilder();

            sqlPesquisa.AppendLine(@"SELECT categoria.id AS Codigo,");
            sqlPesquisa.AppendLine(@"       categoria.DESCRICAO AS Descricao,");
            sqlPesquisa.AppendLine(@"       categoria.TIPO_ID AS CodigoTipo,");
            sqlPesquisa.AppendLine(@"       tipo.DESCRICAO AS DescricaoTipo");
            sqlPesquisa.AppendLine(@"  FROM categoria");
            sqlPesquisa.AppendLine(@"  JOIN tipo ON tipo.ID = categoria.TIPO_ID");

            return _baseRepository.BuscarPorQuery<Categoria>(sqlPesquisa.ToString());
        }
    }
}
