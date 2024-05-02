using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend;
[Table("Sach")]
public class Book
{
    [Column("MaSach")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookId { get; set; }

    [Column("TieuDe")]
    [Required]
    public string? Title { get; set; }

    [Column("TacGia")]
    [Required]
    public string? Author { get; set; }
    [Column("HinhAnh")]
    [Required]
    public string? ImageUrl { get; set; }

    [Column("MoTa")]
    public string? Description { get; set; }

    [Required]
    [Column("GiaTien")]
    public decimal Price { get; set; }

    [Required]
    [Column("SoLuong")]
    public int Quantity { get; set; }
    [Column("TaoLuc")]
    public DateTime? CreateAt {get; set;}
    [Column("CapNhatLuc")]
    public DateTime? UpdateAt {get; set;}
    public int? CategoryId { get; set; }

    // Navigation property
    [ForeignKey("CategoryId")]
    [Column("MaDanhMuc")]
    public Category? Category { get; set; }

    // Constructor
    public Book()
    {
    }
}
