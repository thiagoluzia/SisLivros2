﻿using System.ComponentModel.DataAnnotations;

namespace SisLivros2.Application.DTOs.InputModels
{
    public class AtualizarUsuarioInputModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "O nome de usuário deve conter entre 10 a 150 caracteres.")]
        public string Nome { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "O email do usuário deve conter entre 10 a 150 caracteres.")]
        public string Email { get; set; }

        public AtualizarUsuarioInputModel()
        {
            Nome = string.Empty;
            Email = string.Empty;
        }
    }
}
