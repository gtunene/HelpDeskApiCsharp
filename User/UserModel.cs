namespace HelpDesk.User;
[Table("users")]
public class UserModel
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required, MaxLength(50), EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string Role { get; set; } = "User"; // Default role

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}