using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Services.Models;
using System;
using System.Collections.Generic;

namespace MeusRendimentos.Test.ServiceTests.CategoriaServiceTests
{
    public class CategoriaServiceTestBase
    {
        public List<Categoria> ObterListaCategorias()
        {
            return new List<Categoria>
            {
                new Categoria
                {
                    Codigo = 1,
                    Descricao = "Master",
                    Icone = "",
                    TipoId = 1,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                },
                new Categoria
                {
                    Codigo = 2,
                    Descricao = "Visa",
                    Icone = "",
                    TipoId = 1,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                }
            };
        }
        public Categoria ObterCategoria1() => new Categoria()
        {
            Codigo = 1,
            Descricao = "Master",
            Icone = "",
            TipoId = 1,
            Ativo = true,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now
        };

        public CategoriaModel ObterNovaCategoriaDadosIncompletos() => new CategoriaModel()
        {
            Descricao = "Master"
        };
    }
}
