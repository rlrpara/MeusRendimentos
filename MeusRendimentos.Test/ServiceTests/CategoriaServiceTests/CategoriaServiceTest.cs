using AutoMapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.AutoMapper;
using MeusRendimentos.Services.Models;
using MeusRendimentos.Services.Services;
using Moq;
using System;
using Xunit;

namespace MeusRendimentos.Test.ServiceTests.CategoriaServiceTests
{
    [Trait("Services", "CategoriaService")]
    public class CategoriaServiceTest : CategoriaServiceTestBase
    {
        #region Propriedades Privadas
        private CategoriaService _service;

        #endregion

        #region Construtor
        public CategoriaServiceTest()
        {
            var moqCategoriaRepositorio = new Mock<ICategoriaRepository>().Object;
            var moqMapper = new Mock<IMapper>().Object;
            _service = new CategoriaService(moqCategoriaRepositorio, moqMapper);
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
            var CategoriaMock = new Mock<ICategoriaRepository>();
            var mapperMock = ObterMapperConfig();

            var CategoriaRepository = new CategoriaService(CategoriaMock.Object, mapperMock);

            Assert.True(CategoriaRepository != null);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar Id via método Post")]
        public void DeveInvalidarEnviarIDViaMetodoPost()
        {
            var exception = Assert.Throws<ArgumentException>(() => _service.Post(new CategoriaModel { Codigo = 1 }));

            Assert.Equal("O Código deve ser nulo", exception.Message);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar id vazia ou nulla via GetById")]
        public void DeveInvalidarEnviarIDVaziaNUlaViaGetById()
        {
            var exception = Assert.Throws<ArgumentException>(() => _service.GetById(""));

            Assert.Equal("Código inválido", exception.Message);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar id vazia ou nulla via Put")]
        public void DeveInvalidarEnviarIDVaziaNulaViaPut()
        {
            var exception = Assert.Throws<ArgumentException>(() => _service.Put(new CategoriaModel()));

            Assert.Equal("Código não informado.", exception.Message);
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
            var CategoriaRepository = new Mock<ICategoriaRepository>();

            CategoriaRepository.Setup(x => x.BuscarTodosPorQueryGerador<Categoria>("")).Returns(ObterListaCategorias());

            var resultado = new CategoriaService(CategoriaRepository.Object, ObterMapperConfig()).GetAll();

            Assert.True(resultado.Count > 0);
        }

        [Fact(DisplayName = "Deve retornar um Categoria quando informado seu código válido via GetById")]
        public void DeveRetornarUmCategoriaQuandoInformadoSeuCodigoValidoViaGetById()
        {
            var CategoriaRepository = new Mock<ICategoriaRepository>();

            CategoriaRepository.Setup(x => x.BuscarPorId<Categoria>(1)).Returns(ObterCategoria1());

            var Categoria = new CategoriaService(CategoriaRepository.Object, ObterMapperConfig()).GetById("1");

            Assert.Equal("Master", Categoria.Descricao);
        }

        [Fact(DisplayName = "Deve invalidar quando não enviar um campo obrigatório via Post")]
        public void DeveInvalidaQuandoNaoEnviaCampoObrigatorioViaPost()
        {
            Assert.Equal("O Código deve ser nulo", Assert.Throws<ArgumentException>(() => _service.Post(ObterNovaCategoriaDadosIncompletos())).Message);
        }
    }
}
