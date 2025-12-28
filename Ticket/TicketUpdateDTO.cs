using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Ticket;

public class TicketUpdateDTO
{
    [MaxLength(200)]
    public string? Title { get; set; }

    [MaxLength(200)]
    public string? Description { get; set; }

    [MaxLength(200)]
    public string? Status { get; set; }

    public int? CategoryId { get; set; }

    public int? PriorityId { get; set; }
}