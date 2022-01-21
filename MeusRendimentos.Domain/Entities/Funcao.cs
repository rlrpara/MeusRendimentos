using MeusRendimentos.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeusRendimentos.Domain.Entities
{
    [Table(name: "FUNCAO")]
    public class Funcao : EntityBase
    {
        [Column("NOME", Order = 1)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string Nome { get; set; }

        [Column("DESCRICAO", Order = 2)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string Descricao { get; set; }
    }
}
