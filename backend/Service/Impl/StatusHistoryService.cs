
using AutoMapper;

namespace backend;

public class StatusHistoryService : IStatusHistoryService
{
    private readonly IStatusHistoryRepository _statusHistoryRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    public StatusHistoryService(IMapper mapper, IStatusHistoryRepository statusHistoryRepository, IOrderDetailRepository orderDetailRepository, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _statusHistoryRepository = statusHistoryRepository;
        _orderDetailRepository = orderDetailRepository;
        _bookRepository = bookRepository;
    }
    public async Task<StatusHistory> AddStatusHistory(StatusHistoryRequest statusHistoryRequest)
    {
        StatusHistory statusHistory = _mapper.Map<StatusHistory>(statusHistoryRequest);
        if(statusHistory.OrderStatusId == 3){
            IEnumerable<OrderDetail> orderDetails = await _orderDetailRepository.GetOrderDetailByOrderId(statusHistory.OrderId);
            foreach(OrderDetail orderDetail in orderDetails){
                Book book = await _bookRepository.GetByIdAsync(orderDetail.BookId);
                book.Quantity -= orderDetail.Quantity;
                await _bookRepository.UpdateAsync(book);
            }
        }
        StatusHistory statusHistory1 = await _statusHistoryRepository.AddAsync(statusHistory);
        return statusHistory1;
    }
}
