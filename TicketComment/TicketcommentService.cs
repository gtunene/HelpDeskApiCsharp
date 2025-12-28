using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HelpDesk.User;

namespace HelpDesk.TicketComment;

public class TicketCommentService : ITicketCommentService
{
    private readonly ITicketCommentRepository _repository;
    private readonly IMapper _mapper;

    public TicketCommentService(ITicketCommentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TicketCommentDTO>> GetCommentsForTicketAsync(int ticketId)
    {
        var comments = await _repository.GetCommentsForTicketAsync(ticketId);
        return _mapper.Map<List<TicketCommentDTO>>(comments);
    }

    public async Task<TicketCommentDTO> CreateAsync(int ticketId, TicketCommentCreateDTO commentDto)
    {
        var comment = _mapper.Map<TicketCommentModel>(commentDto);
        comment.TicketId = ticketId;
        var newComment = await _repository.CreateAsync(comment);
        return _mapper.Map<TicketCommentDTO>(newComment);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
