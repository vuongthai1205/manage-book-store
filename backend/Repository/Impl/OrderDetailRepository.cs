
using Microsoft.EntityFrameworkCore;

namespace backend;

public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
{
    BookStoreDbContext _db;
    public OrderDetailRepository(BookStoreDbContext _con) : base(_con)
    {
        _db = _con;
    }

    public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int id)
    {
        try
        {
            var listOrderDetail = await _db.OrderDetails
                                           .Where(x => x.OrderId == id)
                                           .ToListAsync();

            return listOrderDetail;
        }
        catch (Exception ex)
        {
            // Log the exception and return an empty list or rethrow
            // e.g., logger.LogError(ex, "Error fetching order details");
            throw;
        }
    }

}
