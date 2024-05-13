using Microsoft.AspNetCore.Mvc;

namespace backend;
[ApiController]
[Route("api/[controller]")]
public class StatusHistoryController : ControllerBase
{
    private readonly IStatusHistoryService statusHistoryService;
    public StatusHistoryController(IStatusHistoryService statusHistoryService)
    {
        this.statusHistoryService = statusHistoryService;
    }
    [HttpPost]
    public async Task<IActionResult> AddStatusHistory(StatusHistoryRequest statusHistoryRequest)
    {
        await statusHistoryService.AddStatusHistory(statusHistoryRequest);
        return Ok();
    }
}
