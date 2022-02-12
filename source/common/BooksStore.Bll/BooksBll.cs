using Books.Data;
using BooksStore.Core.Common;
using BooksStore.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BooksStore.Bll
{

    public class BooksBll : IBooksBll
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookCacheRepository _bookCacheRepository;
        private readonly ILogger<BooksBll> _logger;

        public BooksBll(IBookRepository bookRepository, IBookCacheRepository bookCacheRepository, ILogger<BooksBll> logger)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));

            _bookCacheRepository = bookCacheRepository ?? throw new ArgumentNullException(nameof(bookCacheRepository));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Book> AddBook(Book book)
        {
            _logger.LogInformation("Received the BooksBll::AddBook() request.");

            var newBook = await _bookRepository
                            .AddBook(book)
                            .ConfigureAwait(false);

            await RemoveAllBooksDataFromCache(Constants.RedisCacheStore.AllBooksKey);

            _logger.LogInformation("Sending output from BooksBll::AddBook() request.");

            return newBook;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            IEnumerable<Book> books;

            _logger.LogInformation("Received the BooksBll::GetAllBooks() request.");

            var booksFromCache = await _bookCacheRepository
                    .RetrieveItemFromCache(Constants.RedisCacheStore.AllBooksKey);

            if (!string.IsNullOrEmpty(booksFromCache))
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                books = JsonSerializer.Deserialize<IEnumerable<Book>>(booksFromCache);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            else
            {
                books = await _bookRepository
                            .GetAllBooks()
                            .ConfigureAwait(false);

                _ = await _bookCacheRepository.SaveOrUpdateItemToCache(
                        Constants.RedisCacheStore.AllBooksKey,
                        JsonSerializer.Serialize(books));
            }

            _logger.LogInformation("Sending output from BooksBll::GetAllBooks() request.");

#pragma warning disable CS8603 // Possible null reference return.
            return books;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Book> GetBookById(int id)
        {
            _logger.LogInformation("Received the BooksBll::GetBookById(id) request.");

            Book book;
            var bookCacheKey = $"{Constants.RedisCacheStore.SingleBookKey}{id}";

            var bookFromCache = await _bookCacheRepository.RetrieveItemFromCache(bookCacheKey);

            if (!string.IsNullOrEmpty(bookFromCache))
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                book = JsonSerializer.Deserialize<Book>(bookFromCache);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            else
            {
                book = await _bookRepository
                            .GetBookById(id)
                            .ConfigureAwait(false);

                _ = await _bookCacheRepository.SaveOrUpdateItemToCache(
                        bookCacheKey,
                        JsonSerializer.Serialize(book));
            }


            _logger.LogInformation("Sending output from BooksBll::GetBookById(id) request.");

#pragma warning disable CS8603 // Possible null reference return.
            return book;
#pragma warning restore CS8603 // Possible null reference return.
        }

        private async Task RemoveAllBooksDataFromCache(string redisCacheKey)
        {
            await _bookCacheRepository.DeleteItemFromCache(redisCacheKey);
        }

    }

}