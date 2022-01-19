using System;

namespace MeusRendimentos.Services.Models
{
    public class CategoriaModel
    {
        public int? Codigo { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }
        public string TipoId { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    }
}
