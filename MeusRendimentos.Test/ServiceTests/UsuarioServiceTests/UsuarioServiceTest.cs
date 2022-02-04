using AutoMapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.AutoMapper;
using MeusRendimentos.Services.Models;
using MeusRendimentos.Services.Services;
using Moq;
using System;
using Xunit;

namespace MeusRendimentos.Test.ServiceTests.UsuarioServiceTests
{
    [Trait("Services", "UsuarioService")]
    public class UsuarioServiceTest : UsuarioServiceTestBase
    {
        #region Propriedades Privadas
        private UsuarioService _service;

        #endregion

        #region Construtor
        public UsuarioServiceTest()
        {
            var moqUsuarioRepositorio = new Mock<IUsuarioRepository>().Object;
            var moqMapper = new Mock<IMapper>().Object;
            _service = new UsuarioService(moqUsuarioRepositorio, moqMapper);
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
            var UsuarioMock = new Mock<IUsuarioRepository>();
            var mapperMock = ObterMapperConfig();

            var UsuarioRepository = new UsuarioService(UsuarioMock.Object, mapperMock);

            Assert.True(UsuarioRepository != null);
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
            var UsuarioRepository = new Mock<IUsuarioRepository>();

            UsuarioRepository.Setup(x => x.BuscarTodosPorQueryGerador<Usuario>("")).Returns(ObterListaUsuario());

            var resultado = new UsuarioService(UsuarioRepository.Object, ObterMapperConfig()).GetAll();

            Assert.True(resultado.Count > 0);
        }

        [Fact(DisplayName = "Deve retornar um Usuario quando informado seu código válido via GetById")]
        public void DeveRetornarUmUsuarioQuandoInformadoSeuCodigoValidoViaGetById()
        {
            var UsuarioRepository = new Mock<IUsuarioRepository>();

            UsuarioRepository.Setup(x => x.BuscarPorId<Usuario>(1)).Returns(ObterUsuario1());

            var Usuario = new UsuarioService(UsuarioRepository.Object, ObterMapperConfig()).GetById("1");

            Assert.Equal("Joao", Usuario.Nome);
        }
    }
}
