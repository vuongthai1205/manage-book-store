using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend;

[Table("LichSuTrangThai")]
public class StatusHistory
{
    [Key]
    [Column("MaLichSuTrangThai")]
    public int Id { get; set; }

    [ForeignKey("Order")]
    [Column("MaDonHang")]
    public int OrderId { get; set; }

    [ForeignKey("OrderStatus")]
    [Column("MaTrangThai")]
    public int OrderStatusId { get; set; }
    
    [Column("GhiChu", TypeName = "nvarchar(MAX)")]
    public string? Note { get; set; }
    [Column("TaoLuc")]
    public DateTime CreateAt { get; set; }

    [Column("CapNhatLuc")]
    public DateTime UpdateAt { get; set; }

    // Thêm khóa ngoại đến bảng ChiTietDonHang
    public virtual required Order Order { get; set; }

    // Thêm khóa ngoại đến bảng TrangThaiDonHang
    public virtual required OrderStatus OrderStatus { get; set; }
    public StatusHistory() {}
}
