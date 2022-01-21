using MeusRendimentos.Infra.Utilities.ExtensionMethods;
using System;
using System.ComponentModel.DataAnnotations;

namespace MeusRendimentos.Services.Models
{
    public class CartaoModel
    {
        private string _descricao;
        private string _bandeira;

        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Descricao
        {
            get { return _descricao.RemoveAcentos(); }
            set { _descricao = value; }
        }
        public string Bandeira
        {
            get { return _bandeira.RemoveAcentos(); }
            set { _bandeira = value; }
        }

        public string Numero { get; set; }
        public double Limite { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int UsuarioId { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    }
}
