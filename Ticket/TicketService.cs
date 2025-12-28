using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HelpDesk.TicketCategory;
using HelpDesk.TicketPriority;
using HelpDesk.User;

namespace HelpDesk.Ticket;

public class TicketService : ITicketService
{
    private readonly TicketRepository _repository;
    private readonly IMapper _mapper;

    public TicketService(TicketRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TicketDTO>> GetAllAsync(int page = 1, int size = 10, string? status = null, int? userId = null, int? categoryId = null, int? priorityId = null, string? q = null)
    {
        var tickets = await _repository.GetAllAsync(page, size, status, userId, categoryId, priorityId, q);
        return _mapper.Map<List<TicketDTO>>(tickets);
    }

    public async Task<TicketDTO?> GetByIdAsync(int id)
    {
        var ticket = await _repository.GetByIdAsync(id);
        return ticket == null ? null : _mapper.Map<TicketDTO>(ticket);
    }

    public async Task<TicketDTO> CreateAsync(TicketCreateDTO ticketDto)
    {
        var ticket = _mapper.Map<TicketModel>(ticketDto);
        ticket.Status = "OPEN"; // Default status for new tickets
        var newTicket = await _repository.CreateAsync(ticket);
        return _mapper.Map<TicketDTO>(newTicket);
    }

    public async Task<TicketDTO?> UpdateAsync(int id, TicketUpdateDTO ticketDto)
    {
        var ticket = await _repository.GetByIdAsync(id);
        if (ticket == null)
        {
            return null;
        }

        _mapper.Map(ticketDto, ticket);
        ticket.UpdatedAt = DateTime.UtcNow; // Update timestamp on modification

        var updatedTicket = await _repository.UpdateAsync(ticket);
        return _mapper.Map<TicketDTO>(updatedTicket);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
