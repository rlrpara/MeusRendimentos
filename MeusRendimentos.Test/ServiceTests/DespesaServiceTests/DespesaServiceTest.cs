using AutoMapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.AutoMapper;
using MeusRendimentos.Services.Models;
using MeusRendimentos.Services.Services;
using Moq;
using System;
using Xunit;

namespace MeusRendimentos.Test.ServiceTests.DespesaServiceTests
{
    [Trait("Services", "DespesaService")]
    public class DespesaServiceTest : DespesaServiceTestBase
    {
        #region Propriedades Privadas
        private DespesaService _service;

        #endregion

        #region Construtor
        public DespesaServiceTest()
        {
            var moqDespesaRepositorio = new Mock<IDespesaRepository>().Object;
            var moqMapper = new Mock<IMapper>().Object;
            _service = new DespesaService(moqDespesaRepositorio, moqMapper);
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
            var DespesaMock = new Mock<IDespesaRepository>();
            var mapperMock = ObterMapperConfig();

            var DespesaRepository = new DespesaService(DespesaMock.Object, mapperMock);

            Assert.True(DespesaRepository != null);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar Id via método Post")]
        public void DeveInvalidarEnviarIDViaMetodoPost()
        {
            var exception = Assert.Throws<ArgumentException>(() => _service.Post(new DespesaModel { Codigo = 1 }));

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
            var DespesaRepository = new Mock<IDespesaRepository>();

            DespesaRepository.Setup(x => x.BuscarTodosPorQueryGerador<Despesa>("")).Returns(ObterListaDespesas());

            var resultado = new DespesaService(DespesaRepository.Object, ObterMapperConfig()).GetAll();

            Assert.True(resultado.Count > 0);
        }

        [Fact(DisplayName = "Deve retornar um Despesa quando informado seu código válido via GetById")]
        public void DeveRetornarUmDespesaQuandoInformadoSeuCodigoValidoViaGetById()
        {
            var DespesaRepository = new Mock<IDespesaRepository>();

            DespesaRepository.Setup(x => x.BuscarPorId<Despesa>(1)).Returns(ObterDespesa1());

            var Despesa = new DespesaService(DespesaRepository.Object, ObterMapperConfig()).GetById("1");

            Assert.Equal("Master", Despesa.Descricao);
        }
    }
}
