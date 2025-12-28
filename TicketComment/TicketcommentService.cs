using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HelpDesk.User;

namespace HelpDesk.TicketComment;

public class TicketCommentService
{
    private readonly TicketCommentRepository _repository;
    private readonly IMapper _mapper;

    public TicketCommentService(TicketCommentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TicketCommentDTO>> GetCommentsForTicketAsync(int ticketId)
    {
        var comments = await _repository.GetCommentsForTicketAsync(ticketId);
        return _mapper.Map<List<TicketCommentDTO>>(comments);
    }

    public async Task<TicketCommentDTO?> GetByIdAsync(int id)
    {
        var comment = await _repository.GetByIdAsync(id);
        return comment == null ? null : _mapper.Map<TicketCommentDTO>(comment);
    }

    public async Task<TicketCommentDTO> CreateAsync(int ticketId, TicketCommentCreateDTO commentDto)
    {
        var comment = _mapper.Map<TicketCommentModel>(commentDto);
        comment.TicketId = ticketId;
        await _repository.AddAsync(comment);
        return _mapper.Map<TicketCommentDTO>(comment);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var comment = await _repository.GetByIdAsync(id);
        if (comment == null)
        {
            return false;
        }
        await _repository.DeleteAsync(comment);
        return true;
    }
}
