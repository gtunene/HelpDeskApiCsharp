using System.ComponentModel.DataAnnotations;

namespace HelpDesk.TicketComment;

public class TicketCommentCreateDTO
{
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public string Message { get; set; } = string.Empty;
}
