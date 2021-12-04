using Books.Data;

namespace BooksStore.Core.Interfaces
{

    public interface IBooksBll
    {
        Task<Book> AddBook(Book video);

        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book> GetBookById(int id);
    }

}
