using HelpDesk.User;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task<UserModel> GetByIdAsync(int id);
    Task<UserModel?> GetUserByEmailAsync(string email);
    Task<List<UserModel>> GetAllUsersAsync();
    Task DeleteUserAsync(UserModel user);
    Task UpdateUserAsync(UserModel user);
    Task AddUserAsync(UserModel user);
}