using FluentValidation;
using SisLivros2.Application.DTOs.InputModels;

namespace SisLivros2.Application.Validators
{
    public class AtualizarEmprestimoInputModelValidation : AbstractValidator<AtualizarEmprestimoInputModel>
    {
        public AtualizarEmprestimoInputModelValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O Id não pode ser vazio ou 0.")
                .NotNull().WithMessage("O Id não pode ser null.");

            RuleFor(x => x.IdLivro)
                .NotEmpty().WithMessage("O Id do livro não pode ser vazio ou 0.")
                .NotNull().WithMessage("O Id do livro não pode ser null.");

            RuleFor(x => x.IdUsuario)
                .NotEmpty().WithMessage("O Id do usuário não pode ser vazio ou 0.")
                .NotNull().WithMessage("O Id do usuário não pode ser null.");

        }
    }
}
