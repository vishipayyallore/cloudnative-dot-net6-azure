using Books.Data;

namespace BooksStore.Core.Interfaces
{

    public interface IBookRepository
    {
        Task<Book> AddBook(Book book);

        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book> GetBookById(int id);
    }

}
