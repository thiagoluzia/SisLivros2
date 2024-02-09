using SisLivros2.Core.Enums;

namespace SisLivros2.Application.DTOs.OutputModels
{
    public class EmprestimoOutputModelModel
    {
        public int Id { get; set; }
        public string TituloLivro { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataEmprestimo { get;  set; }
        public EEmprestimos Situacao { get;  set; }
        public DateTime? Devolvido { get;  set; }

        public EmprestimoOutputModelModel(int id, string tituloLivro, string nomeUsuario, DateTime dataDevolucao, DateTime dataEmprestimo, DateTime devolvido, EEmprestimos situacao)
        {
            Id = id;
            TituloLivro = tituloLivro;
            NomeUsuario = nomeUsuario;
            DataDevolucao = dataDevolucao;
            DataEmprestimo = dataEmprestimo;
            Devolvido = devolvido;
            Situacao = situacao;
        }
    }
}
