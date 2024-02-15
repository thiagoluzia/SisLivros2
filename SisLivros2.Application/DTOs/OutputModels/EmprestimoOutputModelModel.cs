using SisLivros2.Core.Enums;

namespace SisLivros2.Application.DTOs.OutputModels
{
    public class EmprestimoOutputModelModel
    {
        public int Id { get; set; }
        public int IdLivro { get; set; }
        public string TituloLivro { get; set; }
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataEmprestimo { get;  set; }
        public EEmprestimos Situacao { get;  set; }
        public DateTime? Devolvido { get;  set; }

        public EmprestimoOutputModelModel(int id, string tituloLivro, string nomeUsuario, DateTime dataDevolucao, DateTime dataEmprestimo, DateTime devolvido, EEmprestimos situacao, int idLivro, int idUsuario)
        {
            Id = id;
            TituloLivro = tituloLivro;
            NomeUsuario = nomeUsuario;
            DataDevolucao = dataDevolucao;
            DataEmprestimo = dataEmprestimo;
            Devolvido = devolvido;
            Situacao = situacao;
            IdLivro = idLivro;
            IdUsuario = idUsuario;
        }
    }
}
