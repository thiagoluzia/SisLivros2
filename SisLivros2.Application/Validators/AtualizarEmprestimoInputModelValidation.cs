using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SisLivros2.Application.DTOs.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisLivros2.Application.Validators
{
    public class AtualizarEmprestimoInputModelValidation : AbstractValidator<AtualizarEmprestimoInputModel>
    {
        public AtualizarEmprestimoInputModelValidation()
        {
            
        }
    }
}
