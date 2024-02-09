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
            var usuarios = _service.GetAll();

            if (usuarios == null)
            {
                return NotFound($"Nenhum {nameof(usuarios)} encontrado.");
            }

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _service.GetById(id);

            if (usuario == null)
            {
                return NotFound($"{nameof(usuario)} não encontrado.");
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CadastrarUsuarioInputModel inputModel)
        {
            var id = _service.Post(inputModel);

            if (id == 0)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById),new { id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]AtualizarUsuarioInputModel inputModel, int id)
        {
            if(inputModel.Id != id)
            {
                return BadRequest("O Id do usuário não pode ser diferente do id do usuário que deseja atualizar.");
            }

            var usuario = _service.GetById(id);

            if (usuario == null)
            {
                return NotFound($"O {nameof(usuario)} que você está tentando atualizar, não foi encontrado.");
            }

            _service.Put(inputModel);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var usuario = _service.GetById(id);
            if(usuario == null)
            {
                return NotFound($"O {nameof(usuario)} que você está tentando excluir, não foi encontrado.");
            }

            _service.Delete(id);

            return NoContent();
        }
    }
}
