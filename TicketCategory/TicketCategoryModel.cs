using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Models
{
    [Table("ticket_categories")]
    public class TicketCategory
    {
        [Key]
        public int Id {get; set;}
        [Required, MaxLength(100)]
        public string Name {get; set;} = string.Empty;

    }
}