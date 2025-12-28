namespace HelpDesk.User;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateDTO, UserModel>().ReverseMap();
        CreateMap<UserLoginDTO, UserModel>().ReverseMap();
    }
}