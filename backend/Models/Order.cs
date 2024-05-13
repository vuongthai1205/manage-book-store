using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend;

[Table("DonHang")]
public class Order {

    [Key]
    [Column("MaDonHang")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("TenTaiKhoan")]
    public required string Username { get; set; }
    
    [Required]
    [Column("TongTien")]
    public required double TotalPrice { get; set; }
    [Column("GhiChu")]
    public string? Note { get; set; }
    public ICollection<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();
    [Column("TaoLuc")]
    public DateTime CreateAt { get; set; }
    [Column("CapNhatLuc")]
    public DateTime UpdateAt { get; set; }
    public Account? Account { get; set; }
}
