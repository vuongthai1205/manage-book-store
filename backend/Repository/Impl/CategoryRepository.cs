namespace backend;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    BookStoreDbContext _db;
    public CategoryRepository(BookStoreDbContext _con) : base(_con)
    {
        _db = _con;
    }
}
