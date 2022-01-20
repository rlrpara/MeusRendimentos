using MeusRendimentos.Services.Models;
using System.Collections.Generic;

namespace MeusRendimentos.Services.Interfaces
{
    public interface IGanhoService : IBaseService
    {
        List<GanhoModel> GetAll();
        GanhoModel GetById(string id);
        bool Post(GanhoModel GanhoModel);
        bool Put(GanhoModel GanhoModel);
        bool Delete(string id);
    }
}
