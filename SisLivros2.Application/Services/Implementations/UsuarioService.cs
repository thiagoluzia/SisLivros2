using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SisLivros2.Application.DTOs.InputModels;
using SisLivros2.Application.DTOs.OutputModels;
using SisLivros2.Application.Services.Interfaces;
using SisLivros2.Core.Entities;
using SisLivros2.Infrastructure.Persistence;

namespace SisLivros2.Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly SisLivros2DbContext _context;

        public UsuarioService(SisLivros2DbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            try
            {
                var usuario = _context.Usuarios.SingleOrDefault(x => x.Id == id);

                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                    _context.SaveChanges();
                }
            }
            catch (ArgumentNullException ex)
            {
                var mensagemError = "";
                throw new InvalidOperationException(mensagemError, ex);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemError = "O usuario que você está tentando deletar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidDataException(mensagemError, ex);
            }
            catch (DbUpdateException ex)
            {
                var mensagemError = "Erro ao tentar excluir o usuário.";

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

        public List<UsuarioOutputModel> GetAll()
        {
            try
            {
                var usuarios = _context.Usuarios;

                var usuarioOutputModel = usuarios
                    .Select(x => new UsuarioOutputModel(x.Id,x.Nome, x.Email))
                    .ToList();

                return usuarioOutputModel;

            }
            catch (ArgumentNullException ex)
            {
                var mensagemError = "Erro ao selecionar os usuarios. O contexto do banco de dados não pode ser nulo.";
                throw new InvalidOperationException(mensagemError, ex);
            }
            catch (Exception ex)
            {
                var mensagemError = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemError, ex);
            }

        }

        public UsuarioOutputModel GetById(int id)
        {
            try
            {
                var usuario = _context.Usuarios.SingleOrDefault(x => x.Id == id);

                var usuarioOutputModel = new UsuarioOutputModel(usuario.Id, usuario.Nome, usuario.Email);
                return usuarioOutputModel;
            }
            catch (ArgumentNullException ex)
            {
                var mensagemError = "Erro ao selecionar o usuário solicitado. O contexto do banco de dados não pode ser nulo.";
                throw new InvalidOperationException(mensagemError, ex);
            }
            catch (Exception ex)
            {
                var mensagemError = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemError, ex);
            }

        }

        public int Post(CadastrarUsuarioInputModel inputModel)
        {
            try
            {
                var usuario = new Usuario(inputModel.Nome, inputModel.Email);

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return usuario.Id;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemError = "O usuario que você está tentando salvar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidDataException(mensagemError, ex);
            }
            catch (DbUpdateException ex)
            {
                var mensagemError = "Erro ao tentar salvar.";

                if (ex.InnerException is SqlException sqlException)
                {
                    mensagemError = $"Error SQL {sqlException.Number} : {sqlException.Message} ";
                }

                throw new InvalidDataException(mensagemError, ex);
            }
            catch (Exception ex)
            {
                var mensagemError = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";

                throw new InvalidDataException(mensagemError, ex);
            }

        }

        public void Put(AtualizarUsuarioInputModel inputModel)
        {
            try
            {
                var usuario = new Usuario(inputModel.Email, inputModel.Nome);

                usuario.Atualizar(inputModel.Nome, inputModel.Email);

                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemError = "O usuário que você está tentando atualizar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mensagemError, ex);
            }
            catch (DbUpdateException ex)
            {
                var mensagemError = "Erro ao tentar atualizar.";

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
    }
}
