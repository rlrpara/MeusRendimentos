using System;

namespace MeusRendimentos.Services.Models
{
    public class CartaoModel
    {
        public int? Codigo { get; set; }
        public string Descricao { get; set; }
        public string Bandeira { get; set; }
        public string Numero { get; set; }
        public double Limite { get; set; }
        public int UsuarioId { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    }
}
