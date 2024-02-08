using System.ComponentModel.DataAnnotations;

namespace SisLivros2.Application.DTOs.InputModels
{
    public class AtualizarEmprestimoInputModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdLivro { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public DateTime DataDevolucao { get; set; }
    }
}
