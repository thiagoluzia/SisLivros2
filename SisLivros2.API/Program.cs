using Microsoft.EntityFrameworkCore;
using SisLivros2.Application.Services.Implementations;
using SisLivros2.Application.Services.Interfaces;
using SisLivros2.Infrastructure.Persistence;

namespace SisLivros2.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Contexto
            var connection = builder.Configuration.GetConnectionString("SisLivros2cs");
            builder.Services.AddDbContext<SisLivros2DbContext>(options => options.UseSqlServer(connection));
           
            //Injeção de dependencia dos serviços
            builder.Services.AddScoped<ILivroService, LivroService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
