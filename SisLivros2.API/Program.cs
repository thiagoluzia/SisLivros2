using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SisLivros2.API.Filters;
using SisLivros2.Application.Services.Implementations;
using SisLivros2.Application.Services.Interfaces;
using SisLivros2.Application.Validators;
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


            // Adicionando configurações de Filtros e Validações
            builder.Services
            .AddControllers(options => options.Filters.Add(typeof(ValidationFilter))) // configurando os filtros
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CadatrarLivroInputModelValidation>())
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AtualizarLivroInputModelValidation>());// os demais não precisam serem incluidos na config, pois ao carregar o assembly eles ja vem

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
