using System.ComponentModel.DataAnnotations;

namespace HelpDesk.User;

public class UserCreateRequest
{
    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required, MaxLength(50), EmailAddress]
    public string Email { get; set; } = string.Empty;
    // Password will be generated or handled internally, not directly from this DTO for initial creation based on spec
}