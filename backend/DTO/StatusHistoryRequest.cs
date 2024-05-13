namespace backend;
public class StatusHistoryRequest
{
    public int OrderId { get; set; }
    public int OrderStatusId { get; set; }
    public string? Note { get; set; }
}