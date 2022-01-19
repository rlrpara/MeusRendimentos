﻿using MeusRendimentos.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeusRendimentos.Domain.Entities
{
    [Table(name: "USUARIO")]
    public class Login : EntityBase
    {
        [Column("EMAIL")]
        [OpcoesBase(UsarNoBancoDeDados = true, UsarParaBuscar = true)]
        public string Email { get; set; }

        [Column("SENHA")]
        [OpcoesBase(UsarNoBancoDeDados = true, UsarParaBuscar = true)]
        public string Senha { get; set; }
    }
}
