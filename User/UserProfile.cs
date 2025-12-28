using AutoMapper;

namespace HelpDesk.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDTO, UserModel>();
    }
}