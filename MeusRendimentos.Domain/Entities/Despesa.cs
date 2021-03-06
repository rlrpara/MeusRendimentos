using MeusRendimentos.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeusRendimentos.Domain.Entities
{
    [Table(name: "DESPESA")]
    public class Despesa : EntityBase
    {
        [Column("DESCRICAO", Order = 1)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string Descricao { get; set; }

        [Column("CARTAO_ID", Order = 2)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false, ChaveEstrangeira = "CARTAO")]
        public int CartaoId { get; set; }

        [Column("CATEGORIA_ID", Order = 3)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false, ChaveEstrangeira = "CATEGORIA")]
        public int CategoriaId { get; set; }

        [Column("VALOR", Order = 4)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public double Valor { get; set; }

        [Column("DIA", Order = 5)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false)]
        public int Dia { get; set; }

        [Column("MES_ID", Order = 6)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false, ChaveEstrangeira = "MES")]
        public int MesId { get; set; }

        [Column("ANO", Order = 7)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false)]
        public int Ano { get; set; }

        [Column("USUARIO_ID", Order = 8)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false, ChaveEstrangeira = "USUARIO")]
        public int UsuarioId { get; set; }
    }
}
