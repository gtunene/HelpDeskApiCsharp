namespace HelpDesk.Ticket;

[Table("ticket_comments")]
public class TicketCommentModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Message { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public int TicketId { get; set; }
    public TicketModel Ticket { get; set; } = null!;

    [Required]
    public int UserId { get; set; }
    public UserModel User { get; set; } = null!;
}