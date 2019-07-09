using FindBookDomain.Dto;
using FindBookDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindBookDomain.Aplication
{
    public interface IBookService
    {
        List<Book> BuscarLivros(FiltrosDTO filtros);
    }
}
