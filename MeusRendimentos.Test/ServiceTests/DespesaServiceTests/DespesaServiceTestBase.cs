using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Services.Models;
using System;
using System.Collections.Generic;

namespace MeusRendimentos.Test.ServiceTests.DespesaServiceTests
{
    public class DespesaServiceTestBase
    {
        public List<Despesa> ObterListaDespesas()
        {
            return new List<Despesa>
            {
                new Despesa
                {
                    Codigo = 1,
                    Descricao = "Master",
                    Ano = 2022,
                    CartaoId = 1,
                    CategoriaId = 1,
                    Dia = 24,
                    MesId = 1,
                    UsuarioId = 1,
                    Valor = 20,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                },
                new Despesa
                {
                    Codigo = 2,
                    Descricao = "Visa",
                    Ano = 2022,
                    CartaoId = 1,
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
        public Despesa ObterDespesa1() => new Despesa()
        {
            Codigo = 1,
            Descricao = "Master",
            Ano = 2022,
            CartaoId = 1,
            CategoriaId = 1,
            Dia = 24,
            MesId = 1,
            UsuarioId = 1,
            Valor = 20,
            Ativo = true,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now
        };

        public DespesaModel ObterNovaDespesaDadosIncompletos() => new DespesaModel()
        {
            Descricao = "Master"
        };
    }
}
