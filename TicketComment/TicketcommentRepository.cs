using HelpDesk.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.TicketComment;

public class TicketCommentRepository : ITicketCommentRepository
{
    private readonly ApplicationDbContext _context;

    public TicketCommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TicketCommentModel>> GetCommentsForTicketAsync(int ticketId)
    {
        return await _context.TicketComments
            .Where(tc => tc.TicketId == ticketId)
            .Include(tc => tc.User)
            .ToListAsync();
    }

    public async Task<TicketCommentModel> GetByIdAsync(int id)
    {
        return await _context.TicketComments
            .Include(tc => tc.User)
            .FirstOrDefaultAsync(tc => tc.Id == id) ?? throw new KeyNotFoundException("Comment not found");
    }

    public async Task<TicketCommentModel> CreateAsync(TicketCommentModel comment)
    {
        await _context.TicketComments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var comment = await _context.TicketComments.FindAsync(id);
        if (comment == null)
        {
            return false;
        }
        _context.TicketComments.Remove(comment);
        await _context.SaveChangesAsync();
        return true;
    }
}
