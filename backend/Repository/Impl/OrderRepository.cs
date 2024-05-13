
using Microsoft.EntityFrameworkCore;

namespace backend;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    BookStoreDbContext _db;
    public OrderRepository(BookStoreDbContext _con) : base(_con)
    {
        _db = _con;
    }

    public async Task<IEnumerable<Order>> GetAllOrder()
    {
        // Nạp toàn bộ OrderDetails
        var orderResponse = await _db.Orders.Include(p => p.OrderDetails) // Chỉ Include thuộc tính mà không sử dụng Select bên trong
            .ToListAsync();

        if (orderResponse != null)
        {

            return orderResponse;
        }
        else
        {
            return null;
        }
    }

    public async Task<List<Order>> GetOrderByUsername(string username)
    {
        // Nạp toàn bộ OrderDetails
        var orderResponse = await _db.Orders
            .Where(p => p.Username == username)
            .Include(p => p.OrderDetails) // Chỉ Include thuộc tính mà không sử dụng Select bên trong
            .ToListAsync();

        if (orderResponse != null)
        {

            return orderResponse;
        }
        else
        {
            return null;
        }
    }

}
