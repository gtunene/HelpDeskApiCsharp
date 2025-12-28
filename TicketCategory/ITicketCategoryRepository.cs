using HelpDesk.TicketCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITicketCategoryRepository
{
    Task<List<TicketCategoryModel>> GetAllAsync();
    Task<TicketCategoryModel> GetByIdAsync(int id);
    Task<TicketCategoryModel> CreateAsync(TicketCategoryModel category);
    Task<TicketCategoryModel> UpdateAsync(TicketCategoryModel category);
    Task<bool> DeleteAsync(int id);
}