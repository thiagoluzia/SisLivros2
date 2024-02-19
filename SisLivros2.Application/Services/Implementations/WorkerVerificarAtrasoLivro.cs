using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SisLivros2.Application.Services.Interfaces;
using SisLivros2.Core.Enums;
using SisLivros2.Infrastructure.Persistence;

namespace SisLivros2.Application.Services.Implementations
{
    public class  WorkerVerificarAtrasoLivro : BackgroundService, IWorkerVerificarAtrasoLivro
    {
        private readonly SisLivros2DbContext _context;

        public WorkerVerificarAtrasoLivro(SisLivros2DbContext context)
        {
            _context = context;
        }

        public void MarcarAtrasoLivro()
        {

            var emprestimos = _context.Emprestimos
                .Include(e => e.Livro)
                .Where(e => e.DataDevolucao < DateTime.Now && e.Situacao == EEmprestimos.EmAndamento)
                .ToList();

            foreach (var emprestimo in emprestimos)
            {
                emprestimo.AtualizarAtraso();
            }

            _context.SaveChanges();

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                MarcarAtrasoLivro();

                await Task.Delay(TimeSpan.FromHours(24.0), stoppingToken);
            }
            
        }

    }
}
