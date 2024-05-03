namespace backend;

public class StatusHistoryResponse
{

    public int OrderId { get; set; }
    public int OrderStatusId { get; set; }
    
    public string? Note { get; set; }

    // Thêm khóa ngoại đến bảng TrangThaiDonHang
    public virtual required OrderStatus OrderStatus { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public StatusHistoryResponse() {}
}
