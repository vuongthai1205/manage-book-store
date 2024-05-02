using Microsoft.AspNetCore.Mvc;

namespace backend;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService orderService;
    public OrderController(IOrderService orderService)
    {
        this.orderService = orderService;
    }
    [HttpPost]
    public async Task<IActionResult> AddOrder(OrderRequest orderRequest){
        await orderService.AddOrder(orderRequest);
        return  Ok();
    }
}
