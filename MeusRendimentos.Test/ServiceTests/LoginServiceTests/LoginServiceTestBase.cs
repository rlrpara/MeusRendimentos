using MeusRendimentos.Domain.Entities;
using System;

namespace MeusRendimentos.Test.ServiceTests.LoginServiceTests
{
    public class LoginServiceTestBase
    {
        public Login ObterLogin() => new Login()
        {
            Codigo = 1,
            Email = "rlr.para@gmail.com",
            Senha = "12345",
            Ativo = true,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now
        };
    }
}
