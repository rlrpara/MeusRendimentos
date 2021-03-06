using MeusRendimentos.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeusRendimentos.Domain.Entities
{
    [Table(name: "USUARIO")]
    public class Login : EntityBase
    {
        [Column("NOME", Order = 1)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true)]
        public string Nome { get; set; }

        [Column("EMAIL", Order = 2)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true)]
        public string Email { get; set; }

        [Column("SENHA", Order = 3)]
        [OpcoesBaseAttribute(UsarNoBancoDeDados = true, UsarParaBuscar = true)]
        public string Senha { get; set; }
    }
}
