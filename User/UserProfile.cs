namespace HelpDesk.User;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateDTO, UserModel>();
        CreateMap<UserLoginDTO, UserModel>();

        CreateMap<UserDTO, UserModel>();
        CreateMap<UserModel, UserDTO>();
    }
}