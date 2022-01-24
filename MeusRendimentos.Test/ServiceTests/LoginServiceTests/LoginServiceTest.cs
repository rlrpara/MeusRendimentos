using AutoMapper;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.AutoMapper;
using MeusRendimentos.Services.Services;
using Moq;
using Xunit;

namespace MeusRendimentos.Test.ServiceTests.LoginServiceTests
{
    [Trait("Services", "LoginService")]
    public class LoginServiceTest : LoginServiceTestBase
    {
        #region Propriedades Privadas
        private LoginService _service;

        #endregion

        #region Construtor
        public LoginServiceTest()
        {
            var moqLoginRepositorio = new Mock<ILoginRepository>().Object;
            var moqMapper = new Mock<IMapper>().Object;
            _service = new LoginService(moqLoginRepositorio, moqMapper);
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
            var LoginMock = new Mock<ILoginRepository>();
            var mapperMock = ObterMapperConfig();

            var LoginRepository = new LoginService(LoginMock.Object, mapperMock);

            Assert.True(LoginRepository != null);
        }

        [Fact(DisplayName = "Deve retornar um Login quando informado seu código válido via Logar")]
        public void DeveRetornarUmLoginQuandoInformadoSeuCodigoValidoViaLogin()
        {
            var email = "rlr.para@gmail.com";
            var senha = "12345";
            var LoginRepository = new Mock<ILoginRepository>();

            LoginRepository.Setup(x => x.logar(email,senha)).Returns(ObterLogin());

            var loginService = new LoginService(LoginRepository.Object, ObterMapperConfig());
            var login = loginService.logar(email, senha);

            Assert.Equal(email, login.Email);
        }
    }
}
