using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpDesk.Models
{

[Table("tickets")]
public class Ticket
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(200)]

    public string Description { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string Status { get; set; } = "Open";

    // Use UtcNow for Postgres Timestamptz compatibility
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Foreign Keys
    [Required]
    public int UserId { get; set; }
    public UserModel User { get; set; } = null!;

    [Required]
    public int CategoryId { get; set; }
    public TicketCategory Category { get; set; } = null!;

    [Required]
    public int PriorityId { get; set; }
    public Priority Priority { get; set; } = null!;
}
}