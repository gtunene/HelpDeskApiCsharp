using AutoMapper;

namespace HelpDesk.User;

public class UserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserResponseDTO> CreateUserAsync(UserCreateRequest createUserRequest)
    {
        var existingUser = await _repository.GetUserByEmailAsync(createUserRequest.Email);
        if (existingUser != null)
        {
            throw new Exception("User with this email already exists.");
        }
        var user = _mapper.Map<UserModel>(createUserRequest);
        
        // Generate a default password for the new user or handle it as per business logic
        user.Password = PasswordHasher.Hash("DefaultPassword123!"); // Example: Use a strong, generated default password
        user.Role = "User"; // Assign a default role

        await _repository.AddUserAsync(user);
        return _mapper.Map<UserResponseDTO>(user);
    }

    public async Task<UserResponseDTO?> GetUserByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        return user == null ? null : _mapper.Map<UserResponseDTO>(user);
    }

    public async Task<UserResponseDTO?> GetUserByEmailAsync(string email)
    {
        var user = await _repository.GetUserByEmailAsync(email);
        return user == null ? null : _mapper.Map<UserResponseDTO>(user);
    }

    public async Task<UserModel?> LoginAsync(UserLoginDTO loginDto)
    {
        var user = await _repository.GetUserByEmailAsync(loginDto.Email);
        if (user == null || !PasswordHasher.Verify(loginDto.Password, user.Password))
        {
            return null;
        }
        return user;
    }

    public async Task<List<UserResponseDTO>> GetAllUsersAsync(int page, int size, string? search)
    {
        var query = await _repository.GetAllUsersAsync();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(u => u.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                     u.LastName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                     u.Email.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        var users = query.Skip((page - 1) * size).Take(size).ToList();
        
        return _mapper.Map<List<UserResponseDTO>>(users);
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null)
        {
            throw new Exception("User not found.");
        }
        await _repository.DeleteUserAsync(user);
    }

    public async Task<UserResponseDTO> UpdateUserAsync(int id, UserUpdateRequest userUpdateRequest)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        // Apply updates from DTO to UserModel
        if (!string.IsNullOrEmpty(userUpdateRequest.Name))
        {
            user.FirstName = userUpdateRequest.Name;
            // Assuming LastName is not part of the update request based on spec.
            // If it should be handled, further logic is needed here.
        }
        if (!string.IsNullOrEmpty(userUpdateRequest.Email))
        {
            user.Email = userUpdateRequest.Email;
        }

        await _repository.UpdateUserAsync(user);
        return _mapper.Map<UserResponseDTO>(user);
    }
}