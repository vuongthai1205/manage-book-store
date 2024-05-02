using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend;

[Table("TrangThaiDonHang")]
public class OrderStatus
{
    [Key]
    [Column("MaTrangThai")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("TenTrangThai")]
    public required string StatusName { get; set; }


    
}
