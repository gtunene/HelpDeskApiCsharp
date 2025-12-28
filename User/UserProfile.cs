namespace HelpDesk.User;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateDTO, UserModel>();
        CreateMap<UserLoginDTO, UserModel>();

        CreateMap<UserCreateRequest, UserModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LastName, opt => opt.Ignore()); // Or derive from Name if desired

        CreateMap<UserUpdateRequest, UserModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LastName, opt => opt.Ignore()) // Or derive from Name if desired
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); // Only update if not null

        CreateMap<UserResponseDTO, UserModel>();
        CreateMap<UserModel, UserResponseDTO>();
    }
}