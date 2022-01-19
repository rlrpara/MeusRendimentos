using System;

namespace MeusRendimentos.Services.Models
{
    public class DespesaModel
    {
        public int? Codigo { get; set; }
        public string Descricao { get; set; }
        public int CartaoId { get; set; }
        public int CategoriaId { get; set; }
        public double Valor { get; set; }
        public int Dia { get; set; }
        public int MesId { get; set; }
        public int Ano { get; set; }
        public int UsuarioId { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    }
}
