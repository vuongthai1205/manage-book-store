namespace backend;

public class OrderResponse
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public string? Note { get; set; }
    public ICollection<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();
    public ICollection<StatusHistoryResponse>? StatusHistoryResponses { get; set; } = new List<StatusHistoryResponse>();
    public required double TotalPrice { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
