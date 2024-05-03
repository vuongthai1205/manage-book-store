
using Microsoft.EntityFrameworkCore;

namespace backend;

public class StatusHistoryRepository : BaseRepository<StatusHistory>, IStatusHistoryRepository
{
    BookStoreDbContext _db;
    public StatusHistoryRepository(BookStoreDbContext _con) : base(_con)
    {
        _db = _con;
    }

    public async Task<List<StatusHistory>> GetStatusHistoryByOrderId(int orderId)
    {
        List<StatusHistory> statusHistory = await _db.StatusHistories.Where(p => p.OrderId == orderId).Include(p => p.OrderStatus).ToListAsync();
        if (statusHistory != null)
        {

            return statusHistory;
        }
        else
        {
            return null;
        }
    }
}
