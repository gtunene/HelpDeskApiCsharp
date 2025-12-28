using System.ComponentModel.DataAnnotations;

namespace HelpDesk.User;

public class UserUpdateRequest
{
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(50), EmailAddress]
    public string? Email { get; set; }
}