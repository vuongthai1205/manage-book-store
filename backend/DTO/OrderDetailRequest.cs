namespace backend;

public class OrderDetailRequest
{
    public int BookId { get; set; }
    public int Quantity { get; set; }

    public required double UnitPrice { get; set; }
}
