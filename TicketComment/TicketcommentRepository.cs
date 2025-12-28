using HelpDesk.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.TicketComment;

public class TicketCommentRepository
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

    public async Task<TicketCommentModel?> GetByIdAsync(int id)
    {
        return await _context.TicketComments
            .Include(tc => tc.User)
            .FirstOrDefaultAsync(tc => tc.Id == id);
    }

    public async Task AddAsync(TicketCommentModel comment)
    {
        await _context.TicketComments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TicketCommentModel comment)
    {
        _context.TicketComments.Remove(comment);
        await _context.SaveChangesAsync();
    }
}
