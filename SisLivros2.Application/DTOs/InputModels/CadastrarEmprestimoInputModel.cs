using System.ComponentModel.DataAnnotations;

namespace SisLivros2.Application.DTOs.InputModels
{
    public class CadastrarEmprestimoInputModel
    {
        [Required]
        public int IdLivro { get;  set; }
        [Required]
        public int IdUsuario { get;  set; }
        [Required]
        public DateTime DataDevolucao { get; set; }
    }
}
