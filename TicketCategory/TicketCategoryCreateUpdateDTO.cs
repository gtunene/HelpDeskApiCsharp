using System.ComponentModel.DataAnnotations;

namespace HelpDesk.TicketCategory;

public class TicketCategoryCreateUpdateDTO
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}