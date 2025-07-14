using MessengerApp.Services.Models.Users;

namespace MessengerApp.Services.Repositories;

public interface IUserRepository
{
    Task<User> CreateUserAsync(User user);

    Task<User> UpdateUserAsync(User user);

    Task DeleteUserAsync(int userId);

    Task<User> GetUserByIdAsync(int userId);

    Task<User> GetUserByUserNameAsync(string userName);

    Task<IEnumerable<User>> GetAllUsersAsync();
}