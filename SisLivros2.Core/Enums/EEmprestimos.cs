using System.ComponentModel;

namespace SisLivros2.Core.Enums
{
    public enum EEmprestimos
    {
        [Description("Em Andamento")]
        EmAndamento = 0,
        [Description("Atrasado")]
        Atrasado = 1,
        [Description("Devolvido")]
        Devolvido = 2
    }
}
