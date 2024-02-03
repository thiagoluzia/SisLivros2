using SisLivros2.Application.DTOs.InputModels;
using SisLivros2.Application.DTOs.OutputModels;

namespace SisLivros2.Application.Services.Interfaces
{
    public interface ILivroService
    {
        List<LivroOutputModel> GetAll();
        LivroOutputModel GetById(int id);
        int Post(CadastrarLivroInputModel inputModel);
        void Put(AtualizarLivroInputModel inputModel);
        void Delete(int id);

    }
}
