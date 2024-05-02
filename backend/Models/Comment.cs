using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend;

public class Comment
{
    [Column("MaBinhLuan")]
    [Key]
    public int Id { get; set; } // Khóa chính
    [Column("MaSach")]
    [Required]
    public int BookId { get; set; } // Khóa ngoại
    [Column("TenTaiKhoan")]
    [Required]
    public string? Username { get; set; }
    [Column("NoiDung")]
    [Required]
    public string? Content { get; set; }
    [Column("TaoLuc")]
    public DateTime CreateAt { get; set; }
    [Column("CapNhatLuc")]
    public DateTime UpdateAt { get; set; }
    public Book? Book { get; set; }
    public Account? Account { get; set; }
}
