using AutoMapper;

namespace HelpDesk.TicketCategory;

public class TicketCategoryMapping : Profile
{
    public TicketCategoryMapping()
    {
        CreateMap<TicketCategoryModel, TicketCategoryDTO>();
        CreateMap<TicketCategoryDTO, TicketCategoryModel>();
        CreateMap<TicketCategoryCreateUpdateDTO, TicketCategoryModel>();
    }
}