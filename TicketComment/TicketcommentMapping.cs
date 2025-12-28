using AutoMapper;
using HelpDesk.User; // Required for UserResponseDTO mapping

namespace HelpDesk.TicketComment;

public class TicketCommentMapping : Profile
{
    public TicketCommentMapping()
    {
        CreateMap<TicketCommentModel, TicketCommentDTO>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User)); // Map nested User DTO
        CreateMap<TicketCommentCreateDTO, TicketCommentModel>();
    }
}
