using System.Text.RegularExpressions;

namespace SisLivros2.Application.Validators
{
    public static class LivroMetodosValidator
    {
        //Metodos expostos para uso externo na camada de applicação nas validações
        public static bool ValidarISBN(string isbn)
        {
            if (isbn.Length == 10)
            {
                return ValidarISBN10(isbn);
            }
            else
            {
                return ValidarISBN13(isbn);
            }

        }
        public static bool ValidarAnoPublicacao(int ano)
        {
            //return (ano > DateTime.Now.Year) ? false : true;
            return ano <= DateTime.Now.Year; //ano 
        }
        public static bool ValiadarAnoInferior(int ano)
        {
            return ano > 1900;
        }


        //Metodos internos da classe
        private static bool ValidarISBN10(string isbn)
        {
            var regex = new Regex(@"^(?:\d{9}[\dXx])$");
            return regex.IsMatch(isbn);
        }
        private static bool ValidarISBN13(string isbn)
        {
            var regex = new Regex(@"^(?:\d{13})$");
            return regex.IsMatch(isbn);
        }
    }
}
