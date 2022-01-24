using AutoMapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.AutoMapper;
using MeusRendimentos.Services.Models;
using MeusRendimentos.Services.Services;
using Moq;
using System;
using Xunit;

namespace MeusRendimentos.Test.ServiceTests.GanhoServiceTests
{
    [Trait("Services", "GanhoService")]
    public class GanhoServiceTest : GanhoServiceTestBase
    {
        #region Propriedades Privadas
        private GanhoService _service;

        #endregion

        #region Construtor
        public GanhoServiceTest()
        {
            var moqGanhoRepositorio = new Mock<IGanhoRepository>().Object;
            var moqMapper = new Mock<IMapper>().Object;
            _service = new GanhoService(moqGanhoRepositorio, moqMapper);
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
            var GanhoMock = new Mock<IGanhoRepository>();
            var mapperMock = ObterMapperConfig();

            var GanhoRepository = new GanhoService(GanhoMock.Object, mapperMock);

            Assert.True(GanhoRepository != null);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar Id via método Post")]
        public void DeveInvalidarEnviarIDViaMetodoPost()
        {
            var exception = Assert.Throws<ArgumentException>(() => _service.Post(new GanhoModel { Codigo = 1 }));

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
            var GanhoRepository = new Mock<IGanhoRepository>();

            GanhoRepository.Setup(x => x.BuscarTodosPorQueryGerador<Ganho>("")).Returns(ObterListaGanhos());

            var resultado = new GanhoService(GanhoRepository.Object, ObterMapperConfig()).GetAll();

            Assert.True(resultado.Count > 0);
        }

        [Fact(DisplayName = "Deve retornar um Ganho quando informado seu código válido via GetById")]
        public void DeveRetornarUmGanhoQuandoInformadoSeuCodigoValidoViaGetById()
        {
            var GanhoRepository = new Mock<IGanhoRepository>();

            GanhoRepository.Setup(x => x.BuscarPorId<Ganho>(1)).Returns(ObterGanho1());

            var Ganho = new GanhoService(GanhoRepository.Object, ObterMapperConfig()).GetById("1");

            Assert.Equal("Master", Ganho.Descricao);
        }
    }
}
