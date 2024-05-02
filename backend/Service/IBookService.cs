namespace backend;

public interface IBookService
{
    Task<Book> InsertBookAsync(BookRequest book);
    Task<IEnumerable<Book>> GetAll();
    Task<Book> GetBookByIdAsync(int id);
    Task<Book> UpdateBook(int id, BookRequest book);

    Task<bool> DeleteBook(int id);
}
