using MeusRendimentos.Services.Models;

namespace MeusRendimentos.Services.Interfaces
{
    public interface ILoginService : IBaseService
    {
        LoginModel logar(string email, string senha);

        UsuarioAuthenticateResponseModel Authenticate(UsuarioAuthenticateRequestModel usuario);
    }
}
