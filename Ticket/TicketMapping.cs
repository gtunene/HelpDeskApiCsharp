using AutoMapper;
using HelpDesk.TicketCategory;
using HelpDesk.TicketPriority;
using HelpDesk.User;

namespace HelpDesk.Ticket;

public class TicketMapping : Profile
{
    public TicketMapping()
    {
        CreateMap<TicketModel, TicketDTO>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority));
        CreateMap<TicketCreateDTO, TicketModel>();
        CreateMap<TicketUpdateDTO, TicketModel>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
