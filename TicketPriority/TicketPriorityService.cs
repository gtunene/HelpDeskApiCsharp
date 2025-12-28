using AutoMapper;

namespace HelpDesk.TicketPriority;

public class TicketPriorityService : ITicketPriorityService
{
    private readonly ITicketPriorityRepository _repository;
    private readonly IMapper _mapper;

    public TicketPriorityService(ITicketPriorityRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TicketPriorityDTO>> GetAllAsync()
    {
        var priorities = await _repository.GetAllAsync();
        return _mapper.Map<List<TicketPriorityDTO>>(priorities);
    }

    public async Task<TicketPriorityDTO> UpdateAsync(int id, TicketPriorityCreateUpdateDTO priorityDto)
    {
        var priority = await _repository.GetByIdAsync(id);
        _mapper.Map(priorityDto, priority);
        var updatedPriority = await _repository.UpdateAsync(priority);
        return _mapper.Map<TicketPriorityDTO>(updatedPriority);
    }
}