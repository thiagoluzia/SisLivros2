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
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Emprestar([FromBody] CadastrarEmprestimoInputModel inputModel)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Devolver([FromBody] AtualizarEmprestimoInputModel inputModel, int id)
        {
            return Ok();
        }

       
    }
}
