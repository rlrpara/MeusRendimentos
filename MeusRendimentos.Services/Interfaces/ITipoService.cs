using MeusRendimentos.Services.Models;
using System.Collections.Generic;

namespace MeusRendimentos.Services.Interfaces
{
    public interface ITipoService : IBaseService
    {
        List<TipoModel> GetAll();
        TipoModel GetById(string id);
        bool Post(TipoModel TipoModel);
        bool Put(TipoModel TipoModel);
        bool Delete(string id);
    }
}
