using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend;

[Table("Quyen")]
public class Role
{
    [Key]
    [Column("MaQuyen")]
    public int Id { get; set; } 
    [Column("TenQuyen")]

    public string Name { get; set; } 

    public Role(){}
    public Role( string name){
        Name= name;
    }
}
