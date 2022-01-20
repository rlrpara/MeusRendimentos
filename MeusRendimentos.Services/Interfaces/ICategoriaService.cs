using MeusRendimentos.Services.Models;
using System.Collections.Generic;

namespace MeusRendimentos.Services.Interfaces
{
    public interface ICategoriaService : IBaseService
    {
        List<CategoriaModel> GetAll();
        CategoriaModel GetById(string id);
        bool Post(CategoriaModel CategoriaModel);
        bool Put(CategoriaModel CategoriaModel);
        bool Delete(string id);
    }
}
