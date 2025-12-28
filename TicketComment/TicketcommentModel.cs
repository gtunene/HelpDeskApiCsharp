using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Models;

[Table("ticket_comments")]
public class TicketComment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Message { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;

    [Required]
    public int UserId { get; set; }
    public UserModel User { get; set; } = null!;
}