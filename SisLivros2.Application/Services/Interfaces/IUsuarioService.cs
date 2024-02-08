using SisLivros2.Application.DTOs.InputModels;
using SisLivros2.Application.DTOs.OutputModels;

namespace SisLivros2.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioOutputModel> GetAll();
        UsuarioOutputModel GetById(int id);
        int Post(CadastrarUsuarioInputModel inputModel);
        void Put(AtualizarUsuarioInputModel inputModel);
        void Delete(int id);
    }
}
