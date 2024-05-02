namespace backend;

public class OrderStatusRepository : BaseRepository<OrderStatus>, IOrderStatusRepository
{
    public OrderStatusRepository(BookStoreDbContext _con) : base(_con)
    {
    }
}
