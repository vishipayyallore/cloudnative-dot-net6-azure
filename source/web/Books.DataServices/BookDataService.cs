﻿using Books.Data;
using System.Net;
using System.Net.Http.Json;
namespace Books.DataServices
{

    public class BookDataService : IBookDataService
    {
        private readonly HttpClient _httpClient;
        const string booksEndPoint = "api/books";

        public BookDataService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Book>>($"{booksEndPoint}");
        }

        public async Task<bool> AddBook(Book book)
        {
            var result = await _httpClient.PostAsJsonAsync($"{booksEndPoint}", book);

            return (result.StatusCode == HttpStatusCode.OK);
        }

    }

}
