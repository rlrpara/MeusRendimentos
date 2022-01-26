using MeusRendimentos.Infra.Utilities.ExtensionMethods;
using System;
using Xunit;

namespace MeusRendimentos.Test.Utilities.ExtensionMethodsTests.StringExtensionsTests
{
    [Trait("Utilities", "StringExtensions")]
    public class StringExtensionsTest : StringExtensionsTestBase
    {
        [Fact(DisplayName = "Deve retonar sem acentos e maiusculo.")]
        public void DeveRetornarSemAcendoMaiusculo()
        {
            var valor = "Padre do balão.";

            var valorAlterado = valor.RemoveAcentos();

            Assert.Equal("PADRE DO BALAO.", valorAlterado);
        }

        [Fact(DisplayName = "Deve retonar em branco ao validar RemoveAcentos.")]
        public void DeveRetornarBrancoValdarRemoveAcentos()
        {
            var valor = "";

            var valorAlterado = valor.RemoveAcentos();

            Assert.Equal("", valorAlterado);
        }

        [Fact(DisplayName = "Deve retonar apenas numeros")]
        public void DeveRetornarApenasNumeros()
        {
            var valor = "Rua 30 de Abil, 1203.";

            var valorAlterado = valor.ApenasNumeros();

            Assert.Equal("301203", valorAlterado);
        }

        [Fact(DisplayName = "Deve retonar em branco ao validar Apenas Numeros")]
        public void DeveRetornarBrancoValidarApenasNumeros()
        {
            var valor = "";

            var valorAlterado = valor.ApenasNumeros();

            Assert.Equal("", valorAlterado);
        }

        [Fact(DisplayName = "Deve desconverter base 64")]
        public void DeveDesconverterBase64()
        {
            var valor = "VGVzdGUgZGUgY29udmVyc8OjbyBkZSB0ZXh0byBwYXJhIGJhc2UgNjQu";

            var valorAlterado = valor.DecodeBase64();

            Assert.Equal("Teste de conversão de texto para base 64.", valorAlterado);
        }

        [Fact(DisplayName = "Deve retornar em branco ao desconverter base 64")]
        public void DeveRetornarBrancoDesconverterBase64()
        {
            var valor = "";

            var valorAlterado = valor.DecodeBase64();

            Assert.Equal("", valorAlterado);
        }

        [Fact(DisplayName = "Deve codificar ao enviar texto")]
        public void DeveCodificarEnviarTexto()
        {
            var valor = "Teste de conversão de texto para base 64.";

            var valorAlterado = valor.EncodeBase64();

            Assert.Equal("VGVzdGUgZGUgY29udmVyc8OjbyBkZSB0ZXh0byBwYXJhIGJhc2UgNjQu", valorAlterado);
        }

        [Fact(DisplayName = "Deve retornar branco ao converter base 64")]
        public void DeveRetornarBrancoConverterBase64()
        {
            var valor = "";

            var valorAlterado = valor.EncodeBase64();

            Assert.Equal("", valorAlterado);
        }

        [Fact(DisplayName = "Deve retornar apenas texto")]
        public void DeveRetornarApenasTexto()
        {
            var valor = "Masterclass C#, .NET 5, Nuget, GitHub e GitHub Actions | por André Baltieri";

            var valorAlterado = valor.ApenasTexto();

            Assert.Equal("MASTERCLASS C NET 5 NUGET GITHUB E GITHUB ACTIONS  POR ANDRE BALTIERI", valorAlterado);
        }

        [Fact(DisplayName = "Deve retornar apenas texto em branco")]
        public void DeveRetornarApenasTextoEmBranco()
        {
            var valor = "";

            var valorAlterado = valor.ApenasTexto();

            Assert.Equal("", valorAlterado);
        }

        [Fact(DisplayName = "Deve converter text e remover acentos para url")]
        public void DeveConverterTextoRemoverAcentosParaUrl()
        {
            var valor = "Masterclass C#, .NET 5, Nuget, GitHub e GitHub Actions | por André Baltieri";

            var valorAlterado = valor.ToUrl();

            Assert.Equal("masterclass-c-net-5-nuget-github-e-github-actions-por-andre-baltieri", valorAlterado);
        }

        [Fact(DisplayName = "Deve converter text e remover acentos para url em branco")]
        public void DeveConverterTextoRemoverAcentosParaUrlEmBranco()
        {
            var valor = "";

            var valorAlterado = valor.ToUrl();

            Assert.Equal("", valorAlterado);
        }
    }
}
