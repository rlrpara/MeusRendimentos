using MeusRendimentos.Services.Models;
using System.Collections.Generic;

namespace MeusRendimentos.Services.Interfaces
{
    public interface ICartaoService : IBaseService
    {
        List<CartaoModel> GetAll();
        CartaoModel GetById(string id);
        bool Post(CartaoModel CartaoModel);
        bool Put(CartaoModel CartaoModel);
        bool Delete(string id)
    }
}
