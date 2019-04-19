using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infra.Data.Context;

namespace Library.Infra.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context)
            : base(context)
        {

        }
    }
}
