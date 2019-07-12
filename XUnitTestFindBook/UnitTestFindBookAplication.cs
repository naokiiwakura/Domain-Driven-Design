using System;
using Xunit;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using FindBookDomain.Model;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using FindBookCrossCutting;
using FindBookDomain.Aplication;
using FindBookDomain.Repository;
using FindBookAplication;
using System.Threading.Tasks;
using FindBookDomain.Dto;
using System.Linq;
using System.Text;

namespace XUnitTestFindBook
{
    public class UnitTestFindBookAplication
    {
        private readonly IBookService _bookService;
        private readonly Mock<IBookRepository> _bookRepositoryMock = new Mock<IBookRepository>();

        public UnitTestFindBookAplication()
        {
            //Realiza manualmente a injeção de dependência
            _bookService = new BookService(_bookRepositoryMock.Object);
        }

        private List<Book> MockListaLivro()
        {
            var json = File.ReadAllText(@"../../../Mock/books.json", Encoding.GetEncoding("iso-8859-1"));

            var books = JsonConvert.DeserializeObject<List<Book>>(json);

            return books;
        }

        [Theory]
        [InlineData("Jules Verne", 2)]
        [InlineData("J. K. Rowling", 2)]
        [InlineData("J. R. R. Tolkien", 1)]
        [InlineData("J", 5)]
        [InlineData("Gabriel", 0)]
        public void BuscarLivroPorAutor(string nome, int quantidadeRetorno)
        {
            //Arranjo
            var filtro = new FiltrosDTO {
                Autor = nome
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //Ação
            var resultado = _bookService.BuscarLivros(filtro);

            //Confirmação
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }

        [Theory]
        [InlineData("Journey to the Center of the Earth", 1)]
        [InlineData("20,000 Leagues Under the Sea", 1)]
        [InlineData("Harry Potter and the Goblet of Fire", 1)]
        [InlineData("Fantastic Beasts and Where to Find Them: The Original Screenplay", 1)]
        [InlineData("The Lord of the Rings", 1)]
        [InlineData("a", 4)]
        public void BuscarLivroPorNome(string nome, int quantidadeRetorno)
        {
            //Arranjo
            var filtro = new FiltrosDTO
            {
                NomeLivro = nome
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //Ação
            var resultado = _bookService.BuscarLivros(filtro);

            //Confirmação
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }



        [Theory]
        [InlineData(10, 3)]
        [InlineData(11, 1)]
        [InlineData(12, 0)]
        [InlineData(0, 5)]
        public void BuscarLivroPorPrecoInicial(double preco, int quantidadeRetorno)
        {
            //Arranjo
            var filtro = new FiltrosDTO
            {
                PrecoInicial = preco
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //Ação
            var resultado = _bookService.BuscarLivros(filtro);

            //Confirmação
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }

        [Theory]
        [InlineData(6.15, 1)]
        [InlineData(5, 0)]
        [InlineData(7.31, 2)]
        [InlineData(100, 5)]
        public void BuscarLivroPorPrecoFinal(double preco, int quantidadeRetorno)
        {
            //Arranjo
            var filtro = new FiltrosDTO
            {
                PrecoFinal = preco
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //Ação
            var resultado = _bookService.BuscarLivros(filtro);

            //Confirmação
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }



        [Theory]
        [InlineData("Adventure fiction", 2)]
        [InlineData("Adventure Fiction", 1)]
        [InlineData("banana", 0)]
        [InlineData("Science Fiction", 1)]
        public void BuscarLivroPorGenero(string nome, int quantidadeRetorno)
        {
            //Arranjo
            var filtro = new FiltrosDTO
            {
                Genero = nome
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //Ação
            var resultado = _bookService.BuscarLivros(filtro);

            //Confirmação
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }


        [Theory]
        [InlineData("Cliff Wright", 2)]
        [InlineData("Édouard Riou", 2)]
        [InlineData("Mary GrandPré", 1)]
        [InlineData("Tolkien", 1)]
        public void BuscarLivroPorIlustrador(string nome, int quantidadeRetorno)
        {
            //Arranjo
            var filtro = new FiltrosDTO
            {
                Ilustrador = nome
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //Ação
            var resultado = _bookService.BuscarLivros(filtro);

            //Confirmação
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }





        [Theory]
        [InlineData(0, 5)]
        [InlineData(1000, 0)]
        [InlineData(184, 4)]
        [InlineData(213, 4)]
        public void BuscarLivroPorPaginaInicial(int pagina, int quantidadeRetorno)
        {
            //Arranjo
            var filtro = new FiltrosDTO
            {
                QuantidadePaginasInicial = pagina
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //Ação
            var resultado = _bookService.BuscarLivros(filtro);

            //Confirmação
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1000, 5)]
        [InlineData(184, 1)]
        [InlineData(636, 4)]
        public void BuscarLivroPorPaginaFinal(int pagina, int quantidadeRetorno)
        {
            //Arranjo
            var filtro = new FiltrosDTO
            {
                QuantidadePaginasFinal = pagina
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //Ação
            var resultado = _bookService.BuscarLivros(filtro);

            //Confirmação
            Assert.Equal(quantidadeRetorno, resultado.Count);
        }



        [Theory]
        [InlineData("autor", true, 3)]
        [InlineData("autor", false, 1)]
        [InlineData("nome", true, 2)]
        [InlineData("nome", false, 5)]
        [InlineData("preco", true, 5)]
        [InlineData("preco", false, 4)]
        [InlineData("pagina", true, 1)]
        [InlineData("pagina", false, 5)]
        public void BuscarLivroComOrdenacao(string campo,bool crescente, int idDoRegistro)
        {
            //Arranjo
            var filtro = new FiltrosDTO
            {
                CampoOrdenacao = campo,
                Crescente = crescente
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //Ação
            var resultado = _bookService.BuscarLivros(filtro);

            //Confirmação
            Assert.Equal(idDoRegistro, resultado.First().Id);
        }


        [Theory]
        [InlineData(1,2)]
        [InlineData(2,2.02)]
        [InlineData(3,1.462)]
        [InlineData(4,2.23)]
        [InlineData(5,1.23)]
        public void CalcularPrecoDoFrete(int id, double valorDoFrete)
        {
            //Arranjo
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockListaLivro());

            //Ação
            var resultado = _bookService.CalcularFrete(id);

            //Confirmação
            Assert.Equal(valorDoFrete, resultado);
        }


    }
}
