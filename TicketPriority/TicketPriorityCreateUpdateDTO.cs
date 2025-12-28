using System.ComponentModel.DataAnnotations;

namespace HelpDesk.TicketPriority;

public class TicketPriorityCreateUpdateDTO
{
    [Required, MaxLength(50)]
    public string Level { get; set; } = string.Empty;
    [Required, Range(1, 3)]
    public int Rank { get; set; }
}