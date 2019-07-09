using FindBookAplication;
using FindBookDomain.Aplication;
using FindBookDomain.Repository;
using FindBookRepository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FindBookCrossCutting
{
    public class BookInjector
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IBookRepository, BookRepository>();

            //Services
            services.AddScoped<IBookService, BookService>();
        }

    }
}
