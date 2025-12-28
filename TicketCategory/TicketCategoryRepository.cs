using HelpDesk.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.TicketCategory;

public class TicketCategoryRepository
{
    private readonly ApplicationDbContext _context;

    public TicketCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TicketCategoryModel>> GetAllAsync()
    {
        return await _context.TicketCategories.ToListAsync();
    }

    public async Task<TicketCategoryModel?> GetByIdAsync(int id)
    {
        return await _context.TicketCategories.FindAsync(id);
    }

    public async Task AddAsync(TicketCategoryModel category)
    {
        await _context.TicketCategories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TicketCategoryModel category)
    {
        _context.TicketCategories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TicketCategoryModel category)
    {
        _context.TicketCategories.Remove(category);
        await _context.SaveChangesAsync();
    }
}