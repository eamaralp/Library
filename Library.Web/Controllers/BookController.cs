using Library.Web.Models;
using Library.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/books")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<BookModel>> GetAllAsync()
        {
            return await _bookService.GetAllAsync();
        }

        [HttpPost("[action]")]
        public async Task<HttpResponseMessage> PostAsync([FromBody] BookModel book)
        {
            return await _bookService.PostAsync(book);
        }

        [HttpDelete("[action]/{id:guid}")]
        public async Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            return await _bookService.DeleteAsync(id);
        }

        [HttpPut("[action]")]
        public async Task<HttpResponseMessage> PutAsync([FromBody] BookModel book)
        {
            return await _bookService.PutAsync(book);
        }
    }
}
