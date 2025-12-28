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

    public async Task CreateUserAsync(UserCreateDTO createUserDto)
    {
        var existingUser = await _repository.GetUserByEmailAsync(createUserDto.Email);
        if (existingUser != null)
        {
            throw new Exception("User with this email already exists.");
        }
        var user = _mapper.Map<UserModel>(createUserDto);
        user.Password = PasswordHasher.Hash(user.Password);
        await _repository.AddUserAsync(user);
    }

    public async Task<UserDTO?> GetUserByIdAsync(int id)
    {
        var user = await _repository.GetUserByIdAsync(id);
        return user == null ? null : _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO?> GetUserByEmailAsync(string email)
    {
        var user = await _repository.GetUserByEmailAsync(email);
        return user == null ? null : _mapper.Map<UserDTO>(user);
    }
    
}