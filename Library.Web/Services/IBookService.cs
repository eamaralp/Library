using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library.Web.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>> GetAllAsync();
        Task<HttpResponseMessage> PostAsync([FromBody] BookModel book);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}