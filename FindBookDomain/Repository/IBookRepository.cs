using FindBookDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBookDomain.Repository
{
    public interface IBookRepository
    {
        List<Book> Query();
    }
}
