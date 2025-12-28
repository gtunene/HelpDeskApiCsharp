using HelpDesk.TicketPriority;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITicketPriorityRepository
{
    Task<List<TicketPriorityModel>> GetAllAsync();
    Task<TicketPriorityModel> GetByIdAsync(int id);
    Task<TicketPriorityModel> UpdateAsync(TicketPriorityModel priority);
}