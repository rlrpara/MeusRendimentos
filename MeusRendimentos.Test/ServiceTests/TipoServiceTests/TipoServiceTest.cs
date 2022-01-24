using AutoMapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.AutoMapper;
using MeusRendimentos.Services.Models;
using MeusRendimentos.Services.Services;
using Moq;
using System;
using Xunit;

namespace MeusRendimentos.Test.ServiceTests.TipoServiceTests
{
    [Trait("Services", "TipoService")]
    public class TipoServiceTest : TipoServiceTestBase
    {
        #region Propriedades Privadas
        private TipoService _service;

        #endregion

        #region Construtor
        public TipoServiceTest()
        {
            var moqTipoRepositorio = new Mock<ITipoRepository>().Object;
            var moqMapper = new Mock<IMapper>().Object;
            _service = new TipoService(moqTipoRepositorio, moqMapper);
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

        [Fact(DisplayName = "Deve instanciar o objeto.")]
        public void InstanciarObjeto()
        {
            var TipoMock = new Mock<ITipoRepository>();
            var mapperMock = ObterMapperConfig();

            var TipoRepository = new TipoService(TipoMock.Object, mapperMock);

            Assert.True(TipoRepository != null);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar Id via método Post")]
        public void DeveInvalidarEnviarIDViaMetodoPost()
        {
            var exception = Assert.Throws<ArgumentException>(() => _service.Post(new TipoModel { Codigo = 1 }));

            Assert.Equal("O Código deve ser nulo", exception.Message);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar id vazia ou nulla via GetById")]
        public void DeveInvalidarEnviarIDVaziaNUlaViaGetById()
        {
            var exception = Assert.Throws<ArgumentException>(() => _service.GetById(""));

            Assert.Equal("Código inválido", exception.Message);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar id vazia ou nulla via Delete")]
        public void DeveInvalidarEnviarIDVaziaNulaViaDelete()
        {
            Exception exception = Assert.Throws<ArgumentException>(() => _service.Delete(""));

            Assert.Equal("Código não informado.", exception.Message);
        }

        [Fact(DisplayName = "Deve retornar uma lista maior que 0 via GetAll")]
        public void DeveRetornarListaMaiorQueZeroViaGetAll()
        {
            var TipoRepository = new Mock<ITipoRepository>();

            TipoRepository.Setup(x => x.BuscarTodosPorQueryGerador<Tipo>("")).Returns(ObterListaTipo());

            var resultado = new TipoService(TipoRepository.Object, ObterMapperConfig()).GetAll();

            Assert.True(resultado.Count > 0);
        }

        [Fact(DisplayName = "Deve retornar um Tipo quando informado seu código válido via GetById")]
        public void DeveRetornarUmTipoQuandoInformadoSeuCodigoValidoViaGetById()
        {
            var TipoRepository = new Mock<ITipoRepository>();

            TipoRepository.Setup(x => x.BuscarPorId<Tipo>(1)).Returns(ObterTipo1());

            var Tipo = new TipoService(TipoRepository.Object, ObterMapperConfig()).GetById("1");

            Assert.Equal("Fevereiro", Tipo.Descricao);
        }
    }
}
