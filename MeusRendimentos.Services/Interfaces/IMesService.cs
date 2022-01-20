using MeusRendimentos.Services.Models;
using System.Collections.Generic;

namespace MeusRendimentos.Services.Interfaces
{
    public interface IMesService : IBaseService
    {
        List<MesModel> GetAll();
        MesModel GetById(string id);
        bool Post(MesModel MesModel);
        bool Put(MesModel MesModel);
        bool Delete(string id);
    }
}
