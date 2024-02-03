using SisLivros2.Application.DTOs.InputModels;
using SisLivros2.Application.DTOs.OutputModels;
using SisLivros2.Application.Services.Interfaces;
using SisLivros2.Infrastructure.Persistence;
using SisLivros2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SisLivros2.Application.Services.Implementations
{
    public class LivroService : ILivroService
    {
        private readonly SisLivros2DbContext _context;

        public LivroService(SisLivros2DbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
           var livro = _context.Livros.SingleOrDefault(x => x.Id == id);

            if(livro != null)
            {
                _context.Livros.Remove(livro);
                _context.SaveChanges();
            }

        }

        public List<LivroOutputModel> GetAll()
        {
            var livros = _context.Livros;

            var livrosOutputModel = livros
                .Select(x => new LivroOutputModel(x.Id, x.Titulo, x.Autor, x.ISBN, x.AnoPublicacao))
                .ToList();

            return livrosOutputModel;
        }

        public LivroOutputModel GetById(int id)
        {
            var livro = _context.Livros.SingleOrDefault(x =>x.Id == id);

            var livroOutputModel =  new LivroOutputModel 
            (
                livro.Id, 
                livro.Titulo, 
                livro.Autor, 
                livro.ISBN, 
                livro.AnoPublicacao 
            );

            return livroOutputModel;
        }

        public int Post(CadastrarLivroInputModel inputModel)
        {
            var livro = new Livro(inputModel.Titulo, inputModel.Autor, inputModel.ISBN, inputModel.AnoPublicacao);
            
            _context.Livros.Add(livro);
            _context.SaveChanges();

            return livro.Id;

        }

        public void Put(AtualizarLivroInputModel inputModel)
        {
            var livro = _context.Livros.SingleOrDefault(x => x.Id == inputModel.Id);

            livro.Atualizar(inputModel.Titulo,inputModel.Autor, inputModel.ISBN, inputModel.AnoPublicacao);

            _context.SaveChanges();
        }
    }
}
