using HelpDesk.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.TicketPriority;

public class TicketPriorityRepository
{
    private readonly ApplicationDbContext _context;

    public TicketPriorityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TicketPriorityModel>> GetAllAsync()
    {
        return await _context.Priorities.ToListAsync();
    }

    public async Task<TicketPriorityModel?> GetByIdAsync(int id)
    {
        return await _context.Priorities.FindAsync(id);
    }

    public async Task AddAsync(TicketPriorityModel priority)
    {
        await _context.Priorities.AddAsync(priority);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TicketPriorityModel priority)
    {
        _context.Priorities.Update(priority);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TicketPriorityModel priority)
    {
        _context.Priorities.Remove(priority);
        await _context.SaveChangesAsync();
    }
}