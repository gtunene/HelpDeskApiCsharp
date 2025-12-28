namespace HelpDesk.User;


using System.ComponentModel.DataAnnotations;
public class UserDTO
{
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [Required, MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    [Required, MaxLength(50), EmailAddress]
    public string Email { get; set; } = "user@email.com";
    [Required, MaxLength(100)]
    public string Password { get; set; } = string.Empty;
}