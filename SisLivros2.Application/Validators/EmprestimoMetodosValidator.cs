namespace SisLivros2.Application.Validators
{
    public static class EmprestimoMetodosValidator
    {
        public static bool ValidarDataDevolucao(DateTime dataDevolucao)
        {
            //return (dataDevolucao > DateTime.Now) ? false : true;
            //return dataDevolucao <= DateTime.Now; 

            if(dataDevolucao > DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
