using MeusRendimentos.Infra.Utilities.ExtensionMethods;
using Xunit;

namespace MeusRendimentos.Test.Utilities.ExtensionMethodsTests.IntExtensionsTests
{
    [Trait("Utilities", "IntExtensions")]
    public class IntExtensionsTest : IntExtensionsTestBase
    {
        [Fact(DisplayName = "Deve validar valor numerico")]
        public void DeveValidarValorNumerico()
        {
            var valor = "20";

            var ehNumerico = valor.IsNumeric();

            Assert.True(ehNumerico);
        }

        [Fact(DisplayName = "Deve invalidar valor numerico")]
        public void DeveInvalidarValorNumerico()
        {
            var valor = "A";

            var ehNumerico = valor.IsNumeric();

            Assert.False(ehNumerico);
        }
    }
}
