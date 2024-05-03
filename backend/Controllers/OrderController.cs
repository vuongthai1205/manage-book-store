using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<IActionResult> AddOrder(OrderRequest orderRequest){
        await orderService.AddOrder(orderRequest);
        return  Ok();
    }
    [HttpGet("{username}")]
    [Authorize]
    public async Task<ActionResult<List<OrderResponse>>> GetOrder(string username){
        List<OrderResponse> orderResponse = await orderService.GetOrderByUsername(username);
        return Ok(orderResponse);
    }
}
