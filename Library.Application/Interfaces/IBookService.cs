using Library.Domain.Dto;
using System.Collections.Generic;

namespace Library.Application.Services.Intercafes
{
    public interface IBookService
    {
        void Add(BookDto bookDto);
        IEnumerable<BookDto> GetAll();
    }
}