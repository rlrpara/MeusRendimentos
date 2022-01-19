using MeusRendimentos.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeusRendimentos.Domain.Entities
{
    [Table(name: "GANHO")]
    public class Ganho : EntityBase
    {
        [Column("DESCRICAO", Order = 1)]
        [OpcoesBase(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string Descricao { get; set; }

        [Column("CATEGORIA_ID", Order = 3)]
        [OpcoesBase(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false, ChaveEstrangeira = "CATEGORIA")]
        public int CategoriaId { get; set; }

        [Column("VALOR", Order = 4)]
        [OpcoesBase(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public double Valor { get; set; }

        [Column("DIA", Order = 5)]
        [OpcoesBase(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false)]
        public int Dia { get; set; }

        [Column("MES_ID", Order = 6)]
        [OpcoesBase(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false, ChaveEstrangeira = "MES")]
        public int MesId { get; set; }

        [Column("ANO", Order = 7)]
        [OpcoesBase(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false)]
        public int Ano { get; set; }

        [Column("USUARIO_ID", Order = 8)]
        [OpcoesBase(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false, ChaveEstrangeira = "USUARIO")]
        public int UsuarioId { get; set; }
    }
}
