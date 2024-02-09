using FluentValidation;
using SisLivros2.Application.DTOs.InputModels;

namespace SisLivros2.Application.Validators
{
    public class CadastrarEmprestimoInputModelValidation : AbstractValidator<CadastrarEmprestimoInputModel>
    {
        public CadastrarEmprestimoInputModelValidation()
        {
            
            RuleFor(x => x.IdLivro)
                .NotEmpty().WithMessage("O Id do livro não pode ser vazio ou 0.")
                .NotNull().WithMessage("O Id do livro não pode ser null.");

            RuleFor(x => x.IdUsuario)
                .NotEmpty().WithMessage("O Id do usuário não pode ser vazio ou 0.")
                .NotNull().WithMessage("O Id do usuário não pode ser null.");

            RuleFor(x => x.DataDevolucao)
                .NotEmpty().WithMessage("A data de devolução não pode ser vazia.")
                .NotNull().WithMessage("A data de devolução não pode ser null.")
                .Must(EmprestimoMetodosValidator.ValidarDataDevolucao).WithMessage("A data de devolução não pode ser menor ou igual a data a tual.");
        }
    }
}
