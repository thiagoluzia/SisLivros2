namespace SisLivros2.Application.DTOs.InputModels
{
    public class AtualizarLivroInputModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }
    }
}
