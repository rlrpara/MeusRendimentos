namespace MeusRendimentos.Services.Models
{
    public class UsuarioAuthenticateResponseModel
    {
        #region [Propriedades Privadas]
        public LoginModel Login { get; set; }
        public string Token { get; set; }
        #endregion

        #region [Construtor]
        public UsuarioAuthenticateResponseModel(LoginModel login, string token)
        {
            Login = login;
            Token = token;
        }
        #endregion

    }
}
