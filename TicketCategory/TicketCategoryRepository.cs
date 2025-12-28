using HelpDesk.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.TicketCategory;

public class TicketCategoryRepository : ITicketCategoryRepository
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

    public async Task<TicketCategoryModel> GetByIdAsync(int id)
    {
        return await _context.TicketCategories.FindAsync(id) ?? throw new KeyNotFoundException("Category not found");
    }

    public async Task<TicketCategoryModel> CreateAsync(TicketCategoryModel category)
    {
        await _context.TicketCategories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<TicketCategoryModel> UpdateAsync(TicketCategoryModel category)
    {
        _context.TicketCategories.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _context.TicketCategories.FindAsync(id);
        if (category == null)
        {
            return false;
        }

        _context.TicketCategories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}