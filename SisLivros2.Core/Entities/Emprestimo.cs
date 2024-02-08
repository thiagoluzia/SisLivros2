using SisLivros2.Core.Enums;

namespace SisLivros2.Core.Entities
{
    public class Emprestimo : BaseEntity
    {
        public int IdLivro { get; private set; }
        public List<Livro> Livros { get; private set; }
        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucao { get; private set; }
        public EEmprestimos Situacao { get; private set; }
        public DateTime Devolvido { get; private set; }


        public Emprestimo()
        {
            Livros = new List<Livro>();
        }

        public Emprestimo(int idLivro, int idUsuario, DateTime dataDevolucao)
        {
            IdLivro = idLivro;
            IdUsuario = idUsuario;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = dataDevolucao;
            Situacao = EEmprestimos.EmAndamento;
        }


        public void Devolver()
        {
            Devolvido = DateTime.Now;
            Situacao = EEmprestimos.Devolvido;
        }

    }
}
