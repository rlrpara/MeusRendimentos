using MeusRendimentos.Domain.Entities;

namespace MeusRendimentos.Domain.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository
    {
        Categoria ObterCategoriaCompleta();
    }
}
