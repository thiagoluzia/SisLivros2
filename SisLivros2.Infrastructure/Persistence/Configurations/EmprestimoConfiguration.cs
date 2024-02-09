using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisLivros2.Core.Entities;

namespace SisLivros2.Infrastructure.Persistence.Configurations
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasKey(x => x.Id);

            //um emprestimo tem um usuario
            builder
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Emprestimos)
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            // Um empréstimo está associado a apenas um livro
            builder
                .HasOne(x => x.Livro)
                .WithMany()
                .HasForeignKey(x => x.IdLivro)
                .OnDelete(DeleteBehavior.Restrict);
   
        }
    }
}
