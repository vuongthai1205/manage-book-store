using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

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
    [EnableQuery]
    [Authorize]
    public async Task<ActionResult<List<OrderResponse>>> GetOrder(string username){
        List<OrderResponse> orderResponse = await orderService.GetOrderByUsername(username);
        return Ok(orderResponse);
    }

    [HttpGet]
    [EnableQuery]
    [Authorize]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAllOrder(){
        IEnumerable<OrderResponse> orderResponse = await orderService.GetAllOrder();
        return Ok(orderResponse);
    }
}
