using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Services.Models;
using System;
using System.Collections.Generic;

namespace MeusRendimentos.Test.ServiceTests.CartaoServiceTests
{
    public class CartaoServiceTestBase
    {
        public CartaoModel ObterNovoCartao()
        {
            return new CartaoModel
            {
                Descricao = "Master",
                Bandeira = "Master",
                Limite = 100,
                Numero = "1",
                UsuarioId = 1,
                Ativo = true,
                DataCadastro = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };
        }

        public List<Cartao> ObterListaCartaos()
        {
            return new List<Cartao>
            {
                new Cartao
                {
                    Codigo = 1,
                    Descricao = "Master",
                    Bandeira = "Master",
                    Limite = 100,
                    Numero = "1",
                    UsuarioId = 1,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                },
                new Cartao
                {
                    Codigo = 2,
                    Descricao = "Visa",
                    Bandeira = "Visa",
                    Limite = 50,
                    Numero = "5",
                    UsuarioId = 1,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                }
            };
        }

        public Cartao ObterCartao1() => new Cartao()
        {
            Codigo = 1,
            Descricao = "Master",
            Bandeira = "Master",
            Limite = 100,
            Numero = "1",
            UsuarioId = 1,
            Ativo = true,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now
        };

        public CartaoModel ObterNooaCartaoDadosIncompletos() => new CartaoModel()
        {
            Descricao = "Master"
        };
    }
}
