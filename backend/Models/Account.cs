using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend
{
    [Table("TaiKhoan")]
    public class Account
    {
        [Column("TenTaiKhoan")]
        [Key]
        public string Username { get; set; }

        [Column("MatKhau")]
        public string Password { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("AnhDaiDien")]
        public string? Avatar { get; set; }

        [Column("MaQuyen")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        [Column("TrangThai")]
        public string? Status { get; set; }

        [Column("Ten")]
        public string FirstName { get; set; }

        [Column("Ho")]
        public string? LastName { get; set; }

        [Column("NgaySinh")]
        public DateTime? DateOfBirth { get; set; }

        [Column("GioiTinh")]
        public string? Gender { get; set; }

        [Column("DiaChi")]
        public string? Address { get; set; }

        [Column("SoDienThoai")]
        public string? PhoneNumber { get; set; }

        [Column("NgonNguUaThich")]
        public string? LanguagePreference { get; set; }

        [Column("TaoLuc")]
        public DateTime? CreatedAt { get; set; }

        [Column("CapNhatLuc")]
        public DateTime? UpdatedAt { get; set; }
        public Account() { }

        // Constructor
        public Account(string username, string password, string email, string avatar, Role _role, string status,
                       string firstName, string lastName, DateTime dateOfBirth, string gender, string address,
                       string phoneNumber, string languagePreference, DateTime createdAt, DateTime updatedAt)
        {
            Username = username;
            Password = password;
            Email = email;
            Avatar = avatar;
            Role = _role;
            Status = status;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            PhoneNumber = phoneNumber;
            LanguagePreference = languagePreference;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}