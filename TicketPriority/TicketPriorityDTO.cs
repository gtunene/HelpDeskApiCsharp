using System.ComponentModel.DataAnnotations;

namespace HelpDesk.TicketPriority;

public class TicketPriorityDTO
{
    public int Id { get; set; }
    public string Level { get; set; } = string.Empty;
    public int Rank { get; set; }
}