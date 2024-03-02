using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SisLivros2.Application.DTOs.InputModels;
using SisLivros2.Application.DTOs.OutputModels;
using SisLivros2.Application.Services.Interfaces;
using SisLivros2.Core.Entities;
using SisLivros2.Infrastructure.Persistence;

namespace SisLivros2.Application.Services.Implementations
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly SisLivros2DbContext _context;

        public EmprestimoService(SisLivros2DbContext context)
        {
            _context = context;
        }

        public List<EmprestimoOutputModelModel> GetAll()
        {
            try
            {
                var emprestimo = _context.Emprestimos;

                if (!emprestimo.Any())
                {
                    return new List<EmprestimoOutputModelModel>();
                }

                var emprestimoOutputModelModel = emprestimo
                    .Select(x => new EmprestimoOutputModelModel(x.Id, x.Livro.Titulo, x.Usuario.Nome, x.DataDevolucao, x.DataEmprestimo, x.Devolvido ?? DateTime.MinValue, x.Situacao, x.IdLivro, x.IdUsuario))
                    .ToList();

                return emprestimoOutputModelModel;


            }
            catch (ArgumentException ex)
            {
                var mensagemErro = "Erro ao selecionar os emprestimos. O contexto do banco de dados não pode ser nulo.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
        }

        public EmprestimoOutputModelModel GetById(int id)
        {
            try
            {
                var emprestimo = _context.Emprestimos
                    .Include(x => x.Livro)
                    .Include(x => x.Usuario)
                    .SingleOrDefault(x => x.Id == id);

                if (emprestimo == null)
                {
                    return null;
                }

                var emprestimoOutputModelModel = new EmprestimoOutputModelModel
                    (
                        emprestimo.Id,
                        emprestimo.Livro.Titulo,
                        emprestimo.Usuario.Nome,
                        emprestimo.DataDevolucao,
                        emprestimo.DataEmprestimo,
                        emprestimo.Devolvido ?? DateTime.MinValue,
                        emprestimo.Situacao,
                        emprestimo.IdLivro,
                        emprestimo.IdUsuario
                    );

                return emprestimoOutputModelModel;

            }
            catch (ArgumentException ex)
            {
                var mensagemError = "Erro ao selecionar o emprestimo solicitado.";
                throw new InvalidOperationException(mensagemError, ex);
            }
            catch (Exception ex)
            {
                var mensagemError = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemError, ex);
            }
        }

        public int PostEmprestar(CadastrarEmprestimoInputModel inputModel)
        {
            try
            {
                //Validando com metodo da classe
                if (!Emprestado(inputModel.IdLivro))
                {
                    var mesagemError = "O livro não esta disponivel para emprestimo.";
                    throw new InvalidOperationException(mesagemError);
                }
                var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == inputModel.IdUsuario);

                //Validando na controller
                if (usuario == null)
                {
                    var mesagemError = "Usuário não encontrado.";
                    throw new InvalidOperationException(mesagemError);
                }

                var emprestimo = new Emprestimo(inputModel.IdLivro, inputModel.IdUsuario, inputModel.DataDevolucao);

                _context.Emprestimos.Add(emprestimo);
                _context.SaveChanges();

                return emprestimo.Id;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mesagemError = "O emprestimo que você está tentando salvar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mesagemError, ex);

            }
            catch (DbUpdateException ex)
            {
                var mensagemError = "Erro ao tentar salvar.";

                if (ex.InnerException is SqlException sqlException)
                {
                    mensagemError = $"Error SQL {sqlException.Number} : {sqlException.Message}";
                }

                throw new InvalidOperationException(mensagemError, ex);
            }
            catch (Exception ex)
            {
                var mensagemError = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemError, ex);
            }
        }

        public void PutDevolver(AtualizarEmprestimoInputModel inputModel)
        {
            try
            {
                var emprestimo = _context.Emprestimos.SingleOrDefault(x => x.Id == inputModel.Id);

                emprestimo.Devolver(inputModel.IdLivro, inputModel.IdUsuario);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemError = "O emprestimo que você está tentando salvar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mensagemError, ex);
            }
            catch (DbUpdateException ex)
            {
                var mensagemError = "Erro ao tentar salvar.";

                if (ex.InnerException is SqlException sqlException)
                {
                    mensagemError = $"Erro SQL {sqlException.Number} : {sqlException.Message}";
                }

                throw new InvalidOperationException(mensagemError, ex);
            }
            catch (Exception ex)
            {
                var mensagemError = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemError, ex);
            }
        }

        private bool Emprestado(int idLivro)
        {
            var livro = _context.Emprestimos.SingleOrDefault(x => x.IdLivro == idLivro && (x.Situacao != Core.Enums.EEmprestimos.EmAndamento || x.Situacao != Core.Enums.EEmprestimos.Atrasado));

            if (livro.Devolvido == null)
            {
                return false;
            }

            return true;
        }

    }
}