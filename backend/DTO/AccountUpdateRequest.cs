namespace backend;
public class AccountUpdateRequest
{
    public string? Email { get; set; }
    public int? RoleId { get; set; }
    public string? Status { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? LanguagePreference { get; set; }
    public string? Avatar { get; set; }
}