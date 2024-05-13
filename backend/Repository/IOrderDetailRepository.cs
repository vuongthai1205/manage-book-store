namespace backend;

public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int id);
} 
