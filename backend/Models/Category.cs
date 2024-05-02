using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend;
[Table("DanhMuc")]
public class Category
{
    [Key]
    [Column("MaDanhMuc")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }

    [Required]
    [Column("TenDanhMuc")]
    public required string Name { get; set; }
    [Column("TaoLuc")]
    public DateTime? CreateAt {get; set;}
    [Column("CapNhatLuc")]
    public DateTime? UpdateAt {get; set;}

    // Navigation property
    public ICollection<Book>? Books { get; set; } = new List<Book>();
    public Category (){
        
    }
}
