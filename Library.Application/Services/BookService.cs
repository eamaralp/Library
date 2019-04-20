using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Services.Intercafes;
using Library.Domain.Dto;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        public void Add(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            book.Id = Guid.NewGuid();

            _bookRepository.Add(book);
        }

        public IEnumerable<BookDto> GetAll()
        {
            var books = _bookRepository.GetAll().ProjectTo<BookDto>(_mapper.ConfigurationProvider);
            return books.OrderByDescending(x => x.Title);
        }

        public BookDto GetById(Guid id)
        {
            return _mapper.Map<BookDto>(_bookRepository.GetById(id));
        }

        public void Update(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);

            _bookRepository.Update(book);
        }

        public void Delete(Guid id)
        {
            _bookRepository.Remove(id);
        }
    }
}
