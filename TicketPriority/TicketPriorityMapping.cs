using AutoMapper;

namespace HelpDesk.TicketPriority;

public class TicketPriorityMapping : Profile
{
    public TicketPriorityMapping()
    {
        CreateMap<TicketPriorityModel, TicketPriorityDTO>();
        CreateMap<TicketPriorityDTO, TicketPriorityModel>();
        CreateMap<TicketPriorityCreateUpdateDTO, TicketPriorityModel>();
    }
}