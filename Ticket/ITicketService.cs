using HelpDesk.Ticket;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITicketService
{
    Task<List<TicketDTO>> GetAllAsync(int page = 1, int size = 10, string? status = null, int? userId = null, int? categoryId = null, int? priorityId = null, string? q = null);
    Task<TicketDTO?> GetByIdAsync(int id);
    Task<TicketDTO> CreateAsync(TicketCreateDTO ticketDto);
    Task<TicketDTO?> UpdateAsync(int id, TicketUpdateDTO ticketDto);
    Task<bool> DeleteAsync(int id);
}