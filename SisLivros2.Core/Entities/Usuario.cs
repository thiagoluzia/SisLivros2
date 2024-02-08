namespace SisLivros2.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }


        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public void Atualizar(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

    }
}
