﻿using AutoMapper;
using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Domain.Interfaces;
using MeusRendimentos.Services.AutoMapper;
using MeusRendimentos.Services.Models;
using MeusRendimentos.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MeusRendimentos.Test.ServiceTests.MesServiceTests
{
    [Trait("Services", "MesService")]
    public class MesServiceTest : MesServiceTestBase
    {
        #region Propriedades Privadas
        private MesService _service;

        #endregion

        #region Construtor
        public MesServiceTest()
        {
            var moqMesRepositorio = new Mock<IMesRepository>().Object;
            var moqMapper = new Mock<IMapper>().Object;
            _service = new MesService(moqMesRepositorio, moqMapper);
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
            var MesMock = new Mock<IMesRepository>();
            var mapperMock = ObterMapperConfig();

            var MesRepository = new MesService(MesMock.Object, mapperMock);

            Assert.True(MesRepository != null);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar Id via método Post")]
        public void DeveInvalidarEnviarIDViaMetodoPost()
        {
            var exception = Assert.Throws<ArgumentException>(() => _service.Post(new MesModel { Codigo = 1 }));

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
            var MesRepository = new Mock<IMesRepository>();

            MesRepository.Setup(x => x.BuscarTodosPorQueryGerador<Mes>("")).Returns(ObterListaMeses());

            var resultado = new MesService(MesRepository.Object, ObterMapperConfig()).GetAll();

            Assert.True(resultado.Count > 0);
        }

        [Fact(DisplayName = "Deve retornar um Mes quando informado seu código válido via GetById")]
        public void DeveRetornarUmMesQuandoInformadoSeuCodigoValidoViaGetById()
        {
            var MesRepository = new Mock<IMesRepository>();

            MesRepository.Setup(x => x.BuscarPorId<Mes>(1)).Returns(ObterMes1());

            var Mes = new MesService(MesRepository.Object, ObterMapperConfig()).GetById("1");

            Assert.Equal("Fevereiro", Mes.Descricao);
        }
    }
}
