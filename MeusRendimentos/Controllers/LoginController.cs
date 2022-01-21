using MeusRendimentos.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MeusRendimentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region [Propriedades Privadas]
        private readonly ILoginService _service;
        #endregion

        #region [Métodos Privados]
        private object JsonSaida(Services.Models.LoginModel usuarioLogado)
        {
            return new
            {
                Resultado = "OK.",
                Dados = new
                {
                    usuarioLogado.Codigo,
                    usuarioLogado.Email,
                    usuarioLogado.Ativo
                }
            };
        }
        #endregion

        #region [Construtor]
        public LoginController(ILoginService Service) => _service = Service;
        #endregion

        #region [Métodos Públicos]
        /// <summary>
        /// Método para logar no sistema
        /// </summary>
        /// <param name="email">Login de acesso</param>
        /// <param name="senha">Senha de acesso</param>
        /// <response code="200">Retorna com sucesso na requisição</response>
        /// <response code="400">Retorna quando não informado o UID</response>
        /// <response code="404">Retorna como dados não encontrados</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Login")]
        public IActionResult PostLogin(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                return BadRequest($"Usuário/Senha não preenchido");

            var usuarioLogado = _service.logar(email, senha);

            if (usuarioLogado != null)
                return Ok(JsonSaida(usuarioLogado));
            else
                return NotFound(new { Resultado = $"Usuário não encontrado." });
        }
        #endregion
    }
}
