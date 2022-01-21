using AutoMapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.AutoMapper;
using MeusRendimentos.Services.Models;
using MeusRendimentos.Services.Services;
using Moq;
using System;
using Xunit;

namespace MeusRendimentos.Test.ServiceTests.CartaoServiceTests
{
    [Trait("Services", "CartaoService")]
    public class CartaoServiceTest : CartaoServiceTestBase
    {
        #region Propriedades Privadas
        private CartaoService _service;

        #endregion

        #region Construtor
        public CartaoServiceTest()
        {
            var moqCartaoRepositorio = new Mock<ICartaoRepository>().Object;
            var moqMapper = new Mock<IMapper>().Object;
            _service = new CartaoService(moqCartaoRepositorio, moqMapper);
        }

        #endregion

        #region Métodos Privados
        private Mapper ObterMapperConfig()
        {
            var autoMapperProfile = new AutoMapperSetup();
            var configuration = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
            return new Mapper(configuration);
        }
        #endregion

        #region Valida Codigo Obrigatório
        [Fact(DisplayName = "Deve invalidar ao enviar Id via método Post")]
        public void DeveInvalidarEnviarIDViaMetodoPost()
        {
            var exception = Assert.Throws<ArgumentException>(() => _service.Post(new CartaoModel { Codigo = 1 }));

            Assert.Equal("O Código deve ser nulo", exception.Message);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar id vazia ou nulla via GetById")]
        public void DeveInvalidarEnviarIDVaziaNUlaViaGetById()
        {
            Exception exception = Assert.Throws<ArgumentException>(() => _service.GetById(""));

            Assert.Equal("Código inválido", exception.Message);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar id vazia ou nulla via Put")]
        public void DeveInvalidarEnviarIDVaziaNulaViaPut()
        {
            Exception exception = Assert.Throws<ArgumentException>(() => _service.Put(new CartaoModel()));

            Assert.Equal("Campo obrigatório", exception.Message);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar id vazia ou nulla via Delete")]
        public void DeveInvalidarEnviarIDVaziaNulaViaDelete()
        {
            Exception exception = Assert.Throws<ArgumentException>(() => _service.Delete(""));

            Assert.Equal("Código não informado.", exception.Message);
        }

        #endregion

        #region Valida Objetos Corretos
        [Fact(DisplayName = "Deve enviar um objeto válido via Post")]
        public void DeveEnviarUmObjetoValidoViaPost()
        {
            Assert.False(_service.Post(ObterNovoCartao()));
        }

        [Fact(DisplayName = "Deve retornar uma lista maior que 0 via GetAll")]
        public void DeveRetornarListaMaiorQueZeroViaGetAll()
        {
            var CartaoRepository = new Mock<ICartaoRepository>();

            CartaoRepository.Setup(x => x.BuscarTodosPorQueryGerador<Cartao>("")).Returns(ObterListaCartaos());

            var resultado = new CartaoService(CartaoRepository.Object, ObterMapperConfig()).GetAll();

            Assert.True(resultado.Count > 0);
        }

        [Fact(DisplayName = "Deve retornar um Cartao quando informado seu código válido via GetById")]
        public void DeveRetornarUmCartaoQuandoInformadoSeuCodigoValidoViaGetById()
        {
            var CartaoRepository = new Mock<ICartaoRepository>();

            CartaoRepository.Setup(x => x.BuscarPorId<Cartao>(1)).Returns(ObterCartao1());

            var Cartao = new CartaoService(CartaoRepository.Object, ObterMapperConfig()).GetById("1");

            Assert.Equal("Master", Cartao.Descricao);
        }

        #endregion

        #region Valida Campos Obrigatórios
        [Fact(DisplayName = "Deve invalidar quando não enviar um campo obrigatório via Post")]
        public void DeveInvalidaQuandoNaoEnviaCampoObrigatorioViaPost()
        {
            Assert.Equal("O Código deve ser nulo", Assert.Throws<ArgumentException>(() => _service.Post(ObterNooaCartaoDadosIncompletos())).Message);
        }

        [Fact(DisplayName = "Deve validar quando o período for instânciado.")]
        public void DeveValidarQuandoServicoForInstanciado()
        {
            var CartaoMock = new Mock<ICartaoRepository>();

            var CartaoRepository = new CartaoService(CartaoMock.Object, ObterMapperConfig());

            Assert.True(CartaoRepository != null);
        }

        #endregion
    }
}
