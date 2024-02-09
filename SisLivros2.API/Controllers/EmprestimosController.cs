using Microsoft.AspNetCore.Mvc;
using SisLivros2.Application.DTOs.InputModels;
using SisLivros2.Application.Services.Interfaces;

namespace SisLivros2.API.Controllers
{
    [Route("api/[Controller]")]
    public class EmprestimosController : ControllerBase
    {
        private readonly IEmprestimoService _service;

        public EmprestimosController(IEmprestimoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var emprestimos = _service.GetAll();

            if(emprestimos == null)
            {
                return NotFound($"Nenhum {nameof(emprestimos)} encontrado.");
            }

            return Ok(emprestimos);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emprestimo = _service.GetById(id);

            if(emprestimo == null)
            {
                return NotFound($"{nameof(emprestimo)} não encontrado");
            }

            return Ok(emprestimo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CadastrarEmprestimoInputModel inputModel)
        {
            var id = _service.PostEmprestar(inputModel);

            if(id == 0)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Devolver([FromBody] AtualizarEmprestimoInputModel inputModel, int id)
        {

            if(inputModel.Id != id)
            {
                return BadRequest("O Id do emprestimo não pode ser diferente do id do emprestimo que deseja atualizar.");
            }

            var emprestimo = _service.GetById(id);

            if(emprestimo == null)
            {
                return NotFound($"O {nameof(emprestimo)} que você está tentando atualizar, não foi encontrado.");
            }

            _service.PutDevolver(inputModel);

            return NoContent();
        }

    }
}
