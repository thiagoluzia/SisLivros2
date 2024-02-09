namespace SisLivros2.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public List<Emprestimo> Emprestimos { get; private set; }


        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Emprestimos = new List<Emprestimo>();
        }

        public void Atualizar(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

    }
}
