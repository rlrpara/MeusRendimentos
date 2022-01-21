using MeusRendimentos.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeusRendimentos.Domain.Entities
{
    [Table(name: "CARTAO")]
    public class Cartao : EntityBase
    {
        [Column("DESCRICAO", Order = 1)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string Descricao { get; set; }

        [Column("BANDEIRA", Order = 2)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string Bandeira { get; set; }

        [Column("NUMERO", Order = 3)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string Numero { get; set; }

        [Column("LIMITE", Order = 4)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public double Limite { get; set; }

        [Column("USUARIO_ID", Order = 5)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false, ChaveEstrangeira = "USUARIO")]
        public int UsuarioId { get; set; }
    }
}
