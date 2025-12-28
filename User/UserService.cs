using AutoMapper;

namespace HelpDesk.User;

public class UserService
{
    private readonly UserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(UserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateUserAsync(UserDTO userDto)
    {
        var existingUser = await _repository.GetUserByEmailAsync(userDto.Email);
        if (existingUser != null)
        {
            throw new Exception("User with this email already exists.");
        }
        var user = _mapper.Map<UserModel>(userDto);
        
        await _repository.AddUserAsync(user);
    }
}