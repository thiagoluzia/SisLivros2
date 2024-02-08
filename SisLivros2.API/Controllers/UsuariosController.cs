using Microsoft.AspNetCore.Mvc;
using SisLivros2.Application.DTOs.InputModels;
using SisLivros2.Application.Services.Interfaces;

namespace SisLivros2.API.Controllers
{
    [Route("api/[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(CadastrarUsuarioInputModel inputModel)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(AtualizarUsuarioInputModel inputModel)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
