
using AutoMapper;

namespace backend;

public class BookService : IBookService 
{
    private readonly IBookRepository bookRepository;
    private readonly IMapper mapper;
    public BookService(IBookRepository _bookRepository, IMapper _mapper){
        bookRepository = _bookRepository;
        mapper = _mapper;
    }

    public async Task<bool> DeleteBook(int id)
    {
        Book book = await bookRepository.DeleteAsync(id);
        if(book is not null){
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await bookRepository.GetAllAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        return await bookRepository.GetByIdAsync(id);
    }

    public async Task<Book> InsertBookAsync(BookRequest book)
    {
        Book book1 = new();

        mapper.Map(book, book1);
        return await bookRepository.AddAsync(book1);
    }

    public async Task<Book> UpdateBook(int id, BookRequest book)
    {
        Book book1 = await bookRepository.GetByIdAsync(id);
        mapper.Map(book, book1);
        return await bookRepository.UpdateAsync(book1);
    }
}
