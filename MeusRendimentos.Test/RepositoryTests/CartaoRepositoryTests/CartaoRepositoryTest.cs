using AutoMapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Infra.Data.Repositories;
using MeusRendimentos.Services.AutoMapper;
using MeusRendimentos.Services.Services;
using Moq;
using System.Data;
using System.Linq;
using System.Text;
using Xunit;

namespace MeusRendimentos.Test.RepositoryTests.CartaoRepositoryTests
{
    [Trait("Services", "CartaoRepository")]
    public class CartaoRepositoryTest : BaseCartaoRepositoryTest
    {
        #region [Propriedades Privadas]
        
        #endregion

        #region [Métodos Privados]
        private Mapper ObterMapperConfig()
        {
            var autoMapperProfile = new AutoMapperSetup();
            var configuration = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
            return new Mapper(configuration);
        }
        #endregion

        #region [Construtor]
        public CartaoRepositoryTest()
        {

        }
        #endregion

        [Fact(DisplayName = "Deve instanciar o objeto.")]
        public void DeveInstanciarObjeto()
        {
            var baseRepositoryMock = new Mock<ICartaoRepository>();

            var cartaoRepository = new CartaoRepository();

            Assert.True(cartaoRepository != null);
        }

        [Fact(DisplayName = "t")]
        public void t()
        {
            var baseRepositoryMock = new Mock<ICartaoRepository>();

            var cartaoRepository = new CartaoRepository();

            var t = cartaoRepository.BuscarPorQueryGerador<Cartao>("");

            Assert.True(t != null);
        }
    }
}
