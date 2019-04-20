using Library.Domain.Dto;
using System;
using System.Collections.Generic;

namespace Library.Application.Services.Intercafes
{
    public interface IBookService
    {
        void Add(BookDto bookDto);
        IEnumerable<BookDto> GetAll();
        void Update(BookDto bookDto);
        BookDto GetById(Guid id);
        void Delete(Guid id);
    }
}