namespace SisLivros2.Application.DTOs.OutputModels
{
    public class UsuarioOutputModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public UsuarioOutputModel(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
    }
}
