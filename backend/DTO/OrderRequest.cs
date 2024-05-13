namespace backend;

public class OrderRequest
{
    public required string Username { get; set; }
    public string? Note { get; set; }

    public required double TotalPrice { get; set; }
    public ICollection<OrderDetailRequest>? OrderDetailRequests { get; set; } = new List<OrderDetailRequest>();
}
