using HelpDesk.TicketCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITicketCategoryService
{
    Task<List<TicketCategoryDTO>> GetAllAsync();
    Task<TicketCategoryDTO> GetByIdAsync(int id);
    Task<TicketCategoryDTO> CreateAsync(TicketCategoryCreateUpdateDTO categoryDto);
    Task<TicketCategoryDTO> UpdateAsync(int id, TicketCategoryCreateUpdateDTO categoryDto);
    Task<bool> DeleteAsync(int id);
}