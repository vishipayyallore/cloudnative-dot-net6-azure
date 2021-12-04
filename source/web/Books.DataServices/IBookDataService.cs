using Books.Data;

namespace Books.DataServices
{

    public interface IBookDataService
    {
        Task<bool> AddBook(Book book);

        Task<IEnumerable<Book>> GetAllBooks();
    }

}