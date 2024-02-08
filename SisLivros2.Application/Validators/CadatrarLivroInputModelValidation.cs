using FluentValidation;
using SisLivros2.Application.DTOs.InputModels;

namespace SisLivros2.Application.Validators
{
    public  class CadatrarLivroInputModelValidation : AbstractValidator<CadastrarLivroInputModel>
    {
        public CadatrarLivroInputModelValidation()
        {

            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O Título não pode ser vazio.")
                .Length(5, 300).WithMessage("O Título deve ter entre 5 e 300 caracteres.");

            RuleFor(x => x.Autor)
                .NotEmpty().WithMessage("O nome do autor não pode ser vazio.")
                .Length(5, 100).WithMessage("O nome do autor deve ter entre 5 e 100 caracteres.");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("O ISBN do livro não pode ser vazio.")
                .Length(10, 13).WithMessage("O ISBN deve conter de 10 a 13 caracteres.")
                .Must(LivroMetodosValidator.ValidarISBN).WithMessage("O ISBN fornecido não está no formato correto. (ISBN-10 ou ISBN-13).");


            RuleFor(x => x.AnoPublicacao)
                .NotNull().WithMessage("O ano de publicação não pode ser vazio.")
                .Must(LivroMetodosValidator.ValidarAnoPublicacao).WithMessage("O ano da publicação do livro não deve ser maior que ano atual.")
                .Must(LivroMetodosValidator.ValiadaAnoInferior).WithMessage("O Ano de publicação deve ser superior a 1900.");
        
        }

        #region Usado quando não tinha classe separando a responsabilidade
        //private bool ValidarISBN(string isbn)
        //{
        //    if (isbn.Length == 10)
        //    {
        //        return ValidarISBN10(isbn);
        //    }
        //    else
        //    {
        //        return ValidarISBN13(isbn);
        //    }

        //}

        //private static bool ValidarISBN10(string isbn)
        //{
        //    var regex = new Regex(@"^(?:\d{9}[\dXx])$");
        //    return regex.IsMatch(isbn);
        //}
        //private static bool ValidarISBN13(string isbn)
        //{
        //    var regex = new Regex(@"^(?:\d{13})$");
        //    return regex.IsMatch(isbn);
        //}
        //private bool ValidarAnoPublicacao(int ano)
        //{
        //    //return (ano > DateTime.Now.Year) ? false : true;
        //    return ano <= DateTime.Now.Year; //ano 
        //}
        //private bool ValiadaAnoInferior(int ano)
        //{
        //    return ano < 1900;
        //}
        #endregion
    }
}
