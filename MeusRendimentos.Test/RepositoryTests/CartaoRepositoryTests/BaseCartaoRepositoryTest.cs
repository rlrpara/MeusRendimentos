using MeusRendimentos.Domain.Entities;
using System.Collections.Generic;

namespace MeusRendimentos.Test.RepositoryTests.CartaoRepositoryTests
{
    public class BaseCartaoRepositoryTest
    {
        public List<Cartao> ObterLista() => new List<Cartao>()
        {
            new Cartao()
            {
                Codigo = 1,
                Bandeira = "Teste 1"
            },
            new Cartao()
            {
                Codigo = 2,
                Bandeira = "Teste 2"
            }
        };
    }
}
