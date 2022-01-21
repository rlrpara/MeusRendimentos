using MeusRendimentos.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeusRendimentos.Domain.Entities
{
    [Table(name: "CATEGORIA")]
    public class Categoria : EntityBase
    {
        [Column("DESCRICAO", Order = 1)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string Descricao { get; set; }

        [Column("ICONE", Order = 2)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string Icone { get; set; }

        [Column("TIPO_ID", Order = 3)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false, ChaveEstrangeira = "TIPO")]
        public int TipoId { get; set; }
    }
}
