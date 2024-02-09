using SisLivros2.Application.DTOs.InputModels;
using SisLivros2.Application.DTOs.OutputModels;

namespace SisLivros2.Application.Services.Interfaces
{
    public interface IEmprestimoService
    {
        List<EmprestimoOutputModelModel> GetAll();
        EmprestimoOutputModelModel GetById(int id);
        int PostEmprestar(CadastrarEmprestimoInputModel inputModel);
        void PutDevolver(AtualizarEmprestimoInputModel inputModel);
    }
}
