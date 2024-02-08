using FluentValidation;
using SisLivros2.Application.DTOs.InputModels;

namespace SisLivros2.Application.Validators
{
    public  class CadastrarUsuarioInputModelValidation : AbstractValidator<CadastrarUsuarioInputModel>
    {
        public CadastrarUsuarioInputModelValidation()
        {

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do usuário não pode ser vazio.")
                .Length(5, 150).WithMessage("O nome do usuário deve ter entre 5 e 100 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email do usuário não pode ser vazio.")
                .EmailAddress().WithMessage("O email do usuário não é valido.");
        }
    }
}
