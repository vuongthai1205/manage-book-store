namespace backend;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    BookStoreDbContext _db;
    public OrderRepository(BookStoreDbContext _con) : base(_con)
    {
        _db = _con;
    }
}
