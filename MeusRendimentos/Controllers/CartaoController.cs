using MeusRendimentos.Services.Interfaces;
using MeusRendimentos.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MeusRendimentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CartaoController : ControllerBase
    {
        #region [Propriedades Privadas]
        private readonly ICartaoService _service;
        #endregion

        #region [Construtor]
        public CartaoController(ICartaoService service)
            => _service = service;
        #endregion

        #region [Métodos Públicos]
        [HttpGet, AllowAnonymous]
        public IActionResult Get() => Ok(_service.GetAll());

        [HttpGet("{id}"), AllowAnonymous]
        public IActionResult GetId(string id) => Ok(_service.GetById(id));

        [HttpPost]
        public IActionResult Post([FromBody] CartaoModel entidade)
        {
            if (ModelState.IsValid)
            {
                if (_service.GetById(entidade.Codigo.ToString()) == null)
                    return NotFound("Usuário não encontrado.");

                if (_service.Post(entidade))
                    return Created($"api/{RouteData.Values.First().Value}", _service.GetById(entidade.Codigo.ToString()));
                else
                    return BadRequest("Erro ao salvar");
            }

            return BadRequest($"Classe inválida: {ModelState}");
        }

        [HttpPut]
        public IActionResult Put([FromBody] CartaoModel entidade)
        {
            if (ModelState.IsValid)
            {
                if (_service.GetById(entidade.Codigo.ToString()) == null)
                    return NotFound("Usuário não encontrado.");

                if (_service.Put(entidade))
                    return Ok(_service.GetById(entidade.Codigo.ToString()));
                else
                    return BadRequest("Erro ao salvar");
            }

            return BadRequest("Classe inválida");
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(string id)
        {
            if (_service.GetById(id) == null)
                return NotFound();

            return Ok(_service.Delete(id));
        }
        #endregion
    }
}
