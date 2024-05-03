using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend;

[Table("ChiTietDonHang")]
public class OrderDetail
{
    [Key]
    [Column("MaChiTietDonHang")]
    public int Id { get; set; }

    [ForeignKey("Order")]
    [Column("MaDonHang")]
    public int OrderId { get; set; }
    
    [Column("MaSach")]
    public int BookId { get; set; }

    [Required]
    [Column("SoLuong")]
    public int Quantity { get; set; }

    [Required]
    [Column("DonGia")]
    public required double UnitPrice { get; set; }


    [Column("TaoLuc")]
    public DateTime CreateAt { get; set; }

    [Column("CapNhatLuc")]
    public DateTime UpdateAt { get; set; }

    // Thêm khóa ngoại đến bảng Order (DonHang)
    [ForeignKey("OrderId")]
    [JsonIgnore]
    public virtual Order? Order { get; set; }
    
    public Book? Book { get; set; }
}
