using MeusRendimentos.Services.Models;
using System.Collections.Generic;

namespace MeusRendimentos.Services.Interfaces
{
    public interface IDespesaService : IBaseService
    {
        List<DespesaModel> GetAll();
        DespesaModel GetById(string id);
        bool Post(DespesaModel DespesaModel);
        bool Put(DespesaModel DespesaModel);
        bool Delete(string id);
    }
}
