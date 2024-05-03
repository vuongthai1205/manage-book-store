namespace backend;

public interface IOrderService
{
    Task<Order> AddOrder(OrderRequest orderRequest);
    Task< List<OrderResponse>> GetOrderByUsername(string username);
}
