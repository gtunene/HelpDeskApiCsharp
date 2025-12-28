using HelpDesk.TicketPriority;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITicketPriorityService
{
    Task<List<TicketPriorityDTO>> GetAllAsync();
    Task<TicketPriorityDTO> UpdateAsync(int id, TicketPriorityCreateUpdateDTO priorityDto);
}