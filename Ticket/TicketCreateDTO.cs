using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Ticket;

public class TicketCreateDTO
{
    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public int UserId { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int PriorityId { get; set; }
}