using Library.Application.Services;
using Library.Application.Services.Intercafes;
using Library.Domain.Interfaces;
using Library.Infra.Data.Context;
using Library.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IBookService, BookService>();

            // Infra
            services.AddScoped<DbContext, LibraryContext>();
            services.AddScoped<IBookRepository, BookRepository>();
            
        }
    }
}
