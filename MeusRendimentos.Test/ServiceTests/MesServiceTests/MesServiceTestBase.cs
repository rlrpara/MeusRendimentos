using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeusRendimentos.Test.ServiceTests.MesServiceTests
{
    public class MesServiceTestBase
    {
        public List<Mes> ObterListaMeses()
        {
            return new List<Mes>
            {
                new Mes
                {
                    Codigo = 1,
                    Descricao = "Janeiro",
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                },
                new Mes
                {
                    Codigo = 2,
                    Descricao = "Fevereiro",
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                }
            };
        }
        public Mes ObterMes1() => new Mes()
        {
            Codigo = 2,
            Descricao = "Fevereiro",
            Ativo = true,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now
        };

        public MesModel ObterNovaMesDadosIncompletos() => new MesModel()
        {
            Descricao = "Fevereiro"
        };
    }
}
