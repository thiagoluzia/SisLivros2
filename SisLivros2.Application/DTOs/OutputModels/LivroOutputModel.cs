namespace SisLivros2.Application.DTOs.OutputModels
{
    public  class LivroOutputModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }

        public LivroOutputModel(int id, string titulo, string autor, string iSBN, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }

    }
}
