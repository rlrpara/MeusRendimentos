using Xunit;

namespace MeusRendimentos.Test.ServiceTests.CartaoTests
{
    [Trait("Services", "CartaoService")]
    public class CartaoTest
    {
        [Fact(DisplayName = "Teste Base")]
        public void TesteBase()
        {
            var teste = 1;

            Assert.Equal(1, teste);
        }
    }
}
