using HelpDesk.TicketComment;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITicketCommentService
{
    Task<List<TicketCommentDTO>> GetCommentsForTicketAsync(int ticketId);
    Task<TicketCommentDTO> CreateAsync(int ticketId, TicketCommentCreateDTO commentDto);
    Task<bool> DeleteAsync(int id);
}