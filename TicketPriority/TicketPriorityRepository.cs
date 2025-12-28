using HelpDesk.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.TicketPriority;

public class TicketPriorityRepository : ITicketPriorityRepository
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

    public async Task<TicketPriorityModel> GetByIdAsync(int id)
    {
        return await _context.Priorities.FindAsync(id) ?? throw new KeyNotFoundException("Priority not found");
    }

    public async Task<TicketPriorityModel> UpdateAsync(TicketPriorityModel priority)
    {
        _context.Priorities.Update(priority);
        await _context.SaveChangesAsync();
        return priority;
    }
}