using MeusRendimentos.Domain.Entities;
using MeusRendimentos.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeusRendimentos.Test.ServiceTests.UsuarioServiceTests
{
    public class UsuarioServiceTestBase
    {
        public List<Usuario> ObterListaUsuario()
        {
            return new List<Usuario>
            {
                new Usuario
                {
                    Codigo = 1,
                    Nome = "Joao",
                    Email = "Teste@email.com",
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                },
                new Usuario
                {
                    Codigo = 2,
                    Nome = "Maria",
                    Email = "maria@email.com",
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now
                }
            };
        }
        public Usuario ObterUsuario1() => new Usuario()
        {
            Codigo = 1,
            Nome = "Joao",
            Email = "Teste@email.com",
            Ativo = true,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now
        };

        public UsuarioModel ObterNovaMesDadosIncompletos() => new UsuarioModel()
        {
            Nome = "Joao",
        };
    }
}
