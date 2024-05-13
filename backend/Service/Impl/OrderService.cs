
using AutoMapper;

namespace backend;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IStatusHistoryRepository _statusHistoryRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IMapper _mapper;
    public OrderService(IOrderRepository orderRepository, IMapper mapper, IStatusHistoryRepository statusHistoryRepository, IOrderStatusRepository orderStatusRepository)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _statusHistoryRepository = statusHistoryRepository;
        _orderStatusRepository = orderStatusRepository;
    }

    public async Task<Order> AddOrder(OrderRequest orderRequest)
    {
        Order order = _mapper.Map<Order>(orderRequest);
        List<OrderDetail> orderDetails = orderRequest.OrderDetailRequests!.Select(_mapper.Map<OrderDetail>).ToList();
        order.OrderDetails = orderDetails;

        OrderStatus orderStatus = await _orderStatusRepository.GetByIdAsync(1);

        StatusHistory statusHistory = new StatusHistory
        {
            Order = order,
            OrderStatus = orderStatus,
        };
        await _orderRepository.AddAsync(order);
        await _statusHistoryRepository.AddAsync(statusHistory);

        return order;
    }

    public async Task<IEnumerable<OrderResponse>> GetAllOrder()
    {
        IEnumerable<Order> order = await _orderRepository.GetAllOrder();
        IEnumerable<OrderResponse> orderResponse = _mapper.Map<IEnumerable<OrderResponse>>(order);
        foreach (OrderResponse response in orderResponse)
        {
            List<StatusHistory> statusHistory = await _statusHistoryRepository.GetStatusHistoryByOrderId(response.Id);
            response.StatusHistoryResponses = _mapper.Map<List<StatusHistory>, List<StatusHistoryResponse>>(statusHistory);
        }

        return orderResponse;
    }

    public async Task<List<OrderResponse>> GetOrderByUsername(string username)
    {
        List<Order> order = await _orderRepository.GetOrderByUsername(username);
        List<OrderResponse> orderResponse = _mapper.Map<List<OrderResponse>>(order);

        foreach (OrderResponse response in orderResponse)
        {
            List<StatusHistory> statusHistory = await _statusHistoryRepository.GetStatusHistoryByOrderId(response.Id);
            response.StatusHistoryResponses = _mapper.Map<List<StatusHistory>, List<StatusHistoryResponse>>(statusHistory);
        }


        return orderResponse;
    }
}
