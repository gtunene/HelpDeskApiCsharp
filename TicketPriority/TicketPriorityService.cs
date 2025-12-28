using AutoMapper;

namespace HelpDesk.TicketPriority;

public class TicketPriorityService
{
    private readonly TicketPriorityRepository _repository;
    private readonly IMapper _mapper;

    public TicketPriorityService(TicketPriorityRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TicketPriorityDTO>> GetAllAsync()
    {
        var priorities = await _repository.GetAllAsync();
        return _mapper.Map<List<TicketPriorityDTO>>(priorities);
    }

    public async Task<TicketPriorityDTO?> UpdateAsync(int id, TicketPriorityCreateUpdateDTO priorityDto)
    {
        var priority = await _repository.GetByIdAsync(id);
        if (priority == null)
        {
            return null;
        }
        _mapper.Map(priorityDto, priority);
        await _repository.UpdateAsync(priority);
        return _mapper.Map<TicketPriorityDTO>(priority);
    }
}