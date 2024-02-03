using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SisLivros2.Application.DTOs.InputModels;
using SisLivros2.Application.DTOs.OutputModels;
using SisLivros2.Application.Services.Interfaces;

namespace SisLivros2.API.Controllers
{
    [Route("api/[Controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _service;

        public LivrosController(ILivroService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var livros = _service.GetAll();
  
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _service.GetById(id);
    
            return Ok(livro);
        }
  
        [HttpPost]
        public IActionResult Post([FromBody] CadastrarLivroInputModel inputNModel)
        {
            #region Uso individual de validação sem o Filter
            //if (!ModelState.IsValid)
            //{
            //    var messages = ModelState
            //        .SelectMany(ms => ms.Value.Errors)
            //        .Select(e =>e.ErrorMessage)
            //        .ToList();

            //    return BadRequest(messages);
            //}
            #endregion

            var id = _service.Post(inputNModel);

            return CreatedAtAction(nameof(GetById), new {id = id}, inputNModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] AtualizarLivroInputModel inputModel, int id)
        {
            _service.Put(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
