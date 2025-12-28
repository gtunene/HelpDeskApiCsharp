using System.ComponentModel.DataAnnotations;
using HelpDesk.TicketCategory;
using HelpDesk.TicketPriority;
using HelpDesk.User;

namespace HelpDesk.Ticket;

public class TicketDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int UserId { get; set; }
    public UserResponseDTO User { get; set; } = null!;

    public int CategoryId { get; set; }
    public TicketCategoryDTO Category { get; set; } = null!;

    public int PriorityId { get; set; }
    public TicketPriorityDTO Priority { get; set; } = null!;
}