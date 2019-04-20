using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library.Web.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("books");
        }

        public async Task<IEnumerable<BookModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("list-all");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<IEnumerable<BookModel>>();

            return result;
        }

        public async Task<HttpResponseMessage> PostAsync([FromBody] BookModel book)
        {
            var response = await _httpClient.PostAsJsonAsync("post", book);

            return response.EnsureSuccessStatusCode();
        }


        public async Task<BookModel> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"get/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<BookModel>();

            return result;
        }

        public async Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"delete/{id}");

            return response.EnsureSuccessStatusCode();
        }
    }
}
