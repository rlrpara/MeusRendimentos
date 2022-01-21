using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeusRendimentos.Domain.Entities.Base
{
    public class EntityBase
    {
        [Key]
        [Column("ID", Order = 0)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, ChavePrimaria = true, UsarParaBuscar = true)]
        public int? Codigo { get; set; }

        [Column("ATIVO", Order = 97)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true)]
        public bool Ativo { get; set; } = true;

        [Column("DATA_CADASTRO", Order = 98)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true)]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Column("DATA_ATUALIZACAO", Order = 99)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true)]
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    }
}
