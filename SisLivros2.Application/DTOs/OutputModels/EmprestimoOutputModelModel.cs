namespace SisLivros2.Application.DTOs.OutputModels
{
    public class EmprestimoOutputModelModel
    {
        public int Id { get; set; }
        public int IdLivro { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataDevolucao { get; set; }

        public EmprestimoOutputModelModel(int id, int idLivro, int idUsuario, DateTime dataDevolucao)
        {
            Id = id;
            IdLivro = idLivro;
            IdUsuario = idUsuario;
            DataDevolucao = dataDevolucao;
        }
    }
}
