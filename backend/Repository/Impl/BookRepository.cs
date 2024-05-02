namespace backend;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    BookStoreDbContext _db;
    public BookRepository(BookStoreDbContext _con) : base(_con)
    {
        _db = _con;
    }
}
