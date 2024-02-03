using Microsoft.EntityFrameworkCore;
using SisLivros2.Core.Entities;
using System.Reflection;

namespace SisLivros2.Infrastructure.Persistence
{
    public  class SisLivros2DbContext : DbContext 
    {
        public DbSet<Livro> Livros { get; set; }

        public SisLivros2DbContext(DbContextOptions<SisLivros2DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
