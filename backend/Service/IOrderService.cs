namespace backend;

public interface IOrderService
{
    Task<Order> AddOrder(OrderRequest orderRequest);
}
