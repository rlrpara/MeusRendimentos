using MeusRendimentos.Services.Models;
using System.Collections.Generic;

namespace MeusRendimentos.Services.Interfaces
{
    public interface IUsuarioService : IBaseService
    {
        List<UsuarioModel> GetAll();
        UsuarioModel GetById(string id);
        bool Post(UsuarioModel UsuarioModel);
        bool Put(UsuarioModel UsuarioModel);
        bool Delete(string id);
    }
}
