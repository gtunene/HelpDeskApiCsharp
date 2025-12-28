namespace HelpDesk.TicketCategory
{
    [Table("ticket_categories")]
    public class TicketCategoryModel
    {
        [Key]
        public int Id {get; set;}
        [Required, MaxLength(100)]
        public string Name {get; set;} = string.Empty;

    }
}