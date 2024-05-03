
using Microsoft.EntityFrameworkCore;

namespace backend;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    BookStoreDbContext _db;
    public OrderRepository(BookStoreDbContext _con) : base(_con)
    {
        _db = _con;
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
            // Sau khi đã nạp dữ liệu, bạn có thể truy cập hoặc tính toán giá trị cần thiết
            foreach (var order in orderResponse)
            {
                var unitPrices = order.OrderDetails!.Select(od => od.UnitPrice).ToList(); // Thực hiện Select sau khi dữ liệu đã được Include
            }

            return orderResponse;
        }
        else
        {
            return null;
        }
    }

}
