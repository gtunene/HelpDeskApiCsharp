using HelpDesk.TicketComment;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITicketCommentRepository
{
    Task<List<TicketCommentModel>> GetCommentsForTicketAsync(int ticketId);
    Task<TicketCommentModel> CreateAsync(TicketCommentModel comment);
    Task<bool> DeleteAsync(int id);
    Task<TicketCommentModel> GetByIdAsync(int id);
}