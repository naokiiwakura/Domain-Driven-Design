using FindBookDomain.Aplication;
using FindBookDomain.Dto;
using FindBookDomain.Model;
using FindBookDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindBookAplication
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public List<Book> BuscarLivros(FiltrosDTO filtros)
        {
            var livros = _repo.Query();

            if (!string.IsNullOrEmpty(filtros.Autor))
                livros = livros.Where(p => p.Specifications.Author.Contains(filtros.Autor)).ToList();

            if (!string.IsNullOrEmpty(filtros.NomeLivro))
                livros = livros.Where(p => p.Name.Contains(filtros.NomeLivro)).ToList();

            if (filtros.PrecoInicial != null)
                livros = livros.Where(p => p.Price >= filtros.PrecoInicial).ToList();

            if (filtros.PrecoFinal != null)
                livros = livros.Where(p => p.Price <= filtros.PrecoFinal).ToList();

            if (!string.IsNullOrEmpty(filtros.Genero))
                livros = livros.Where(p => p.Specifications.Genres.Contains(filtros.Genero)).ToList();

            if (!string.IsNullOrEmpty(filtros.Ilustrador))
                livros = livros.Where(p => p.Specifications.Illustrator.Contains(filtros.Ilustrador)).ToList();

            if (filtros.QuantidadePaginasInicial != null)
                livros = livros.Where(p => p.Specifications.PageCount >= filtros.QuantidadePaginasInicial).ToList();

            if (filtros.QuantidadePaginasFinal != null)
                livros = livros.Where(p => p.Specifications.PageCount <= filtros.QuantidadePaginasFinal).ToList();


            switch (filtros.CampoOrdenacao)
            {
                case "autor":
                    livros = filtros.Crescente ? livros.OrderBy(p => p.Specifications.Author).ToList() : livros.OrderByDescending(p => p.Specifications.Author).ToList();
                    break;

                case "nome":
                    livros = filtros.Crescente ? livros.OrderBy(p => p.Name).ToList() : livros.OrderByDescending(p => p.Name).ToList();
                    break;

                case "preco":
                    livros = filtros.Crescente ? livros.OrderBy(p => p.Price).ToList() : livros.OrderByDescending(p => p.Price).ToList();
                    break;

                case "genero":
                    livros = filtros.Crescente ? livros.OrderBy(p => p.Specifications.Genres).ToList() : livros.OrderByDescending(p => p.Specifications.Genres).ToList();
                    break;

                case "ilustrador":
                    livros = filtros.Crescente ? livros.OrderBy(p => p.Specifications.Illustrator).ToList() : livros.OrderByDescending(p => p.Specifications.Illustrator).ToList();
                    break;

                case "pagina":
                    livros = filtros.Crescente ? livros.OrderBy(p => p.Specifications.PageCount).ToList() : livros.OrderByDescending(p => p.Specifications.PageCount).ToList();
                    break;

                default:
                    break;
            }


            return livros;
        }
    }
}
