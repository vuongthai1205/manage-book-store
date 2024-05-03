namespace backend;

public interface IStatusHistoryRepository : IRepository<StatusHistory>
{
    Task<List<StatusHistory>> GetStatusHistoryByOrderId(int orderId);
}
