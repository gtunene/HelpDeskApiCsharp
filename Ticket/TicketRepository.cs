using HelpDesk.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Ticket;

public class TicketRepository
{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TicketModel>> GetAllAsync(int page, int size, string? status, int? userId, int? categoryId, int? priorityId, string? q)
    {
        var query = _context.Tickets
            .Include(t => t.User)
            .Include(t => t.Category)
            .Include(t => t.Priority)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(t => t.Status == status);
        }

        if (userId.HasValue)
        {
            query = query.Where(t => t.UserId == userId.Value);
        }

        if (categoryId.HasValue)
        {
            query = query.Where(t => t.CategoryId == categoryId.Value);
        }

        if (priorityId.HasValue)
        {
            query = query.Where(t => t.PriorityId == priorityId.Value);
        }

        if (!string.IsNullOrWhiteSpace(q))
        {
            query = query.Where(t => t.Title.Contains(q) || t.Description.Contains(q));
        }

        return await query.Skip((page - 1) * size).Take(size).ToListAsync();
    }

    public async Task<TicketModel?> GetByIdAsync(int id)
    {
        return await _context.Tickets
            .Include(t => t.User)
            .Include(t => t.Category)
            .Include(t => t.Priority)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(TicketModel ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TicketModel ticket)
    {
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TicketModel ticket)
    {
        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
    }
}
