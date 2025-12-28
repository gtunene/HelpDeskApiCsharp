using HelpDesk.Ticket;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITicketRepository
{
    Task<List<TicketModel>> GetAllAsync(int page, int size, string? status, int? userId, int? categoryId, int? priorityId, string? q);
    Task<TicketModel> GetByIdAsync(int id);
    Task<TicketModel> CreateAsync(TicketModel ticket);
    Task<TicketModel> UpdateAsync(TicketModel ticket);
    Task<bool> DeleteAsync(int id);
}