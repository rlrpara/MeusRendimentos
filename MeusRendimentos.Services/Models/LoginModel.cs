﻿using System;

namespace MeusRendimentos.Services.Models
{
    public class LoginModel
    {
        public int? Codigo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    }
}
