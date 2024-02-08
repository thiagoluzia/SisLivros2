using FluentValidation;
using SisLivros2.Application.DTOs.InputModels;

namespace SisLivros2.Application.Validators
{
    public class AtualizarUsuarioInputModelValidation : AbstractValidator<AtualizarUsuarioInputModel>
    {
        public AtualizarUsuarioInputModelValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O Id não pode ser vazio ou 0.")
                .NotNull().WithMessage("O Id não pode ser null.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do usuário não pode ser vazio.")
                .Length(5, 150).WithMessage("O nome do usuário deve ter entre 5 e 100 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email do usuário não pode ser vazio.")
                .EmailAddress().WithMessage("O email do usuário não é valido.");
        }
    }
}
