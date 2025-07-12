using MessengerApp.Services.Models.Users;

namespace MessengerApp.Services.Repositories;

public interface IUserRepository
{
    Task<Users> CreateUserAsync(Users user);

    Task<Users> UpdateUserAsync(Users user);

    Task DeleteUserAsync(int userId);

    Task<Users> GetUserByIdAsync(int userId);

    Task<Users> GetUserByUserNameAsync(string userName);

    Task<IEnumerable<Users>> GetAllUsersAsync();
}