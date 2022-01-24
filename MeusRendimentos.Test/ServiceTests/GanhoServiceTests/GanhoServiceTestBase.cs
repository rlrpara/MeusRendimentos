using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeusRendimentos.Test.ServiceTests.GanhoServiceTests
{
    public class GanhoServiceTestBase
    {
        public List<Ganho> ObterListaGanhos()
        {
            return new List<Ganho>
            {
                new Ganho
                {
                    Codigo = 1,
                    Descricao = "Master",
                    Ano = 2022,
                    CategoriaId = 1,
                    Dia = 24,
                    MesId = 1,
                    UsuarioId = 1,
                    Valor = 20,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                },
                new Ganho
                {
                    Codigo = 2,
                    Descricao = "Visa",
                    Ano = 2022,
                    CategoriaId = 1,
                    Dia = 16,
                    MesId = 1,
                    UsuarioId = 1,
                    Valor = 15,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                }
            };
        }
        public Ganho ObterGanho1() => new Ganho()
        {
            Codigo = 1,
            Descricao = "Master",
            Ano = 2022,
            CategoriaId = 1,
            Dia = 24,
            MesId = 1,
            UsuarioId = 1,
            Valor = 20,
            Ativo = true,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now
        };

        public GanhoModel ObterNovaGanhoDadosIncompletos() => new GanhoModel()
        {
            Descricao = "Master"
        };
    }
}
