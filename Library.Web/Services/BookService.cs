using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
            var httpContent = new StringContent(JsonConvert.SerializeObject(book));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync("post", httpContent);

            return response.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> PutAsync([FromBody] BookModel book)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(book));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PutAsync("update", httpContent);

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
