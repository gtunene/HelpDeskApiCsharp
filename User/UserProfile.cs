using AutoMapper; // Add this to fix the red squiggle
using HelpDesk.User;

namespace HelpDesk.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDTO, UserModel>();
    }
}