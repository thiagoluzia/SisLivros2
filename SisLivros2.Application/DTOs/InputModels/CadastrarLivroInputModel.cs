using System.ComponentModel.DataAnnotations;

namespace SisLivros2.Application.DTOs.InputModels
{
    public class CadastrarLivroInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O Título deve ter entre 5 e 30 caracteres.")]
        public string Titulo { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "O nome do autor deve ter entre 20 e 100 caracteres.")]
        public string Autor { get; set; }
        [Required]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "O ISBN deve conter de 10 a 13 caracteres.")]
        public string ISBN { get; set; }
        [Required]
        public int AnoPublicacao { get; set; }
    }
}
