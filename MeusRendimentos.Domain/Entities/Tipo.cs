using MeusRendimentos.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeusRendimentos.Domain.Entities
{
    [Table(name: "TIPO")]
    public class Tipo : EntityBase
    {
        [Column("DESCRICAO", Order = 1)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false)]
        public string Descricao { get; set; }
    }
}
