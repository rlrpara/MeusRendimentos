using MeusRendimentos.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeusRendimentos.Domain.Entities
{
    [Table(name: "USUARIO")]
    public class Usuario : EntityBase
    {
        [Column("NOME", Order = 1)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string Nome { get; set; }

        [Column("EMAIL", Order = 2)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string Email { get; set; }

        [Column("SENHA", Order = 3)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = false)]
        public string Senha { get; set; }

        [Column("CPF", Order = 4)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public string CPF { get; set; }

        [Column("FOTO", Order = 5)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true)]
        public byte[] Foto { get; set; }

        [Column("FUNCAO_ID", Order = 6)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true, UsarNaGrid = true, ChaveEstrangeira = "FUNCAO")]
        public int FuncaoId { get; set; } = 2;
    }
}
