using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Services.Models;
using System;
using System.Collections.Generic;

namespace MeusRendimentos.Test.ServiceTests.TipoServiceTests
{
    public class TipoServiceTestBase
    {
        public List<Tipo> ObterListaTipo()
        {
            return new List<Tipo>
            {
                new Tipo
                {
                    Codigo = 1,
                    Descricao = "Janeiro",
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                },
                new Tipo
                {
                    Codigo = 2,
                    Descricao = "Fevereiro",
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                }
            };
        }
        public Tipo ObterTipo1() => new Tipo()
        {
            Codigo = 2,
            Descricao = "Fevereiro",
            Ativo = true,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now
        };

        public TipoModel ObterNovaMesDadosIncompletos() => new TipoModel()
        {
            Descricao = "Fevereiro"
        };
    }
}
