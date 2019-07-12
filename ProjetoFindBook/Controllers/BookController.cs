using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindBookAplication;
using FindBookDomain.Aplication;
using FindBookDomain.Dto;
using FindBookDomain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFindBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        public List<Book> Get([FromQuery]string autor, [FromQuery]string nomelivro, 
            [FromQuery]double? precoinicial, [FromQuery]double? precofinal, 
            [FromQuery]string genero, [FromQuery]string ilustrador, 
            [FromQuery]int? quantidadepaginasinicial, [FromQuery]int? quantidadepaginasfinal)
        {

            var filtros = new FiltrosDTO
            {
                Autor = autor,
                NomeLivro = nomelivro,
                PrecoInicial = precoinicial,
                PrecoFinal = precofinal,
                Genero = genero,
                Ilustrador = ilustrador,
                QuantidadePaginasInicial = quantidadepaginasinicial,
                QuantidadePaginasFinal = quantidadepaginasfinal,
            };
            
            return _service.BuscarLivros(filtros);
        }
    }
}