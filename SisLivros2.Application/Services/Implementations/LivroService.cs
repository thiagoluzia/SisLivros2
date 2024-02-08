using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SisLivros2.Application.DTOs.InputModels;
using SisLivros2.Application.DTOs.OutputModels;
using SisLivros2.Application.Services.Interfaces;
using SisLivros2.Core.Entities;
using SisLivros2.Infrastructure.Persistence;
using System.Data;


namespace SisLivros2.Application.Services.Implementations
{
    public class LivroService : ILivroService
    {
        private readonly SisLivros2DbContext _context;

        public LivroService(SisLivros2DbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
 
            try
            {
                var livro = _context.Livros.SingleOrDefault(x => x.Id == id);

                if (livro != null)
                {
                    _context.Livros.Remove(livro);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemErro = "O livro que você está tentando excluir foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mensagemErro, ex);

            }
            catch (DbUpdateException ex)
            {
                var mensagemErro = "Erro ao tentar excluir o livro.";

                if(ex.InnerException is SqlException sqlException)
                {
                    mensagemErro = $" Error SQL {sqlException.Number}: {sqlException.Message}";
                }

                throw new  InvalidOperationException(mensagemErro, ex);
            }
            catch(Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            
        }

        public List<LivroOutputModel> GetAll()
        {

            try
            {
                var livros = _context.Livros;

                var livrosOutputModel = livros
                    .Select(x => new LivroOutputModel(x.Id, x.Titulo, x.Autor, x.ISBN, x.AnoPublicacao))
                    .ToList();

                return livrosOutputModel;
            }
            catch (ArgumentNullException ex)
            {
                var mensagemErro = "Erro ao selecionar os livros. O contexto do banco de dados não pode ser nulo.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch(Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
           
        }

        public LivroOutputModel GetById(int id)
        {

            try
            {
                var livro = _context.Livros.SingleOrDefault(x => x.Id == id);

                if(livro == null)
                {
                    return null;
                }

                var livroOutputModel = new LivroOutputModel
                (
                    livro.Id,
                    livro.Titulo,
                    livro.Autor,
                    livro.ISBN,
                    livro.AnoPublicacao
                );

                return livroOutputModel;
            }
            catch (ArgumentNullException ex)
            {
                var mensagemErro = "Erro ao selecionar o livro solicitado. O contexto do banco de dados não pode ser nulo.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            
        }

        public int Post(CadastrarLivroInputModel inputModel)
        {

            try
            {
                var livro = new Livro(inputModel.Titulo, inputModel.Autor, inputModel.ISBN, inputModel.AnoPublicacao);

                _context.Livros.Add(livro);
                _context.SaveChanges();

                return livro.Id;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemErro = "O livro que você está tentando salvar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mensagemErro, ex);

            }
            catch (DbUpdateException ex)
            {
                var mensagemErro = "Erro ao tentar salvar.";

                if (ex.InnerException is SqlException sqlException)
                {
                    mensagemErro = $" Error SQL {sqlException.Number}: {sqlException.Message}";
                }

                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }

        }

        public void Put(AtualizarLivroInputModel inputModel)
        {

            try
            {
                var livro = new Livro(
                    inputModel.Titulo, 
                    inputModel.Autor, 
                    inputModel.ISBN, 
                    inputModel.AnoPublicacao);

                livro.Atualizar(inputModel.Titulo, inputModel.Autor, inputModel.ISBN, inputModel.AnoPublicacao);

                _context.SaveChanges();
            }
            catch (ArgumentNullException ex)
            {
                var mensagemErro = "Erro ao tentar atualizar o livro informado, livro não encontrado. O contexto do banco de dados não pode ser nulo.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemErro = "O livro que você está tentando atualizar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mensagemErro, ex);

            }
            catch (DbUpdateException ex)
            {
                var mensagemErro = "Erro ao tentar atualizar.";

                if (ex.InnerException is SqlException sqlException)
                {
                    mensagemErro = $" Error SQL {sqlException.Number}: {sqlException.Message}";
                }

                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }

        }

    }
}
