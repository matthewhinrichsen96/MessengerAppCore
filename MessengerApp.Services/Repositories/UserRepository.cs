using MessengerApp.Services.Data;
using MessengerApp.Services.Models.Users;
using Npgsql;

namespace MessengerApp.Services.Repositories;

public class UserRepository(IConfiguration configuration) : IUserRepository
{
    private readonly IConfiguration _configuration = configuration;
    private readonly AppDbContext _dbContext = new(configuration);

    public async Task<User> CreateUserAsync(User user)
    {
        _ = _dbContext.Set<User>().Add(user);
        _ = await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _ = _dbContext.Set<User>().Update(user);
        _ = await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = _dbContext.Set<User>().FirstOrDefault(u => u.UserId == userId);

        _dbContext.RemoveRange(user!);

        _ = await _dbContext.SaveChangesAsync();
    }

    public Task<User> GetUserByIdAsync(int userId)
    {
        var user = _dbContext.Set<User>().FirstOrDefault(u => u.UserId == userId);

        return Task.FromResult(user!);
    }

    public Task<User> GetUserByUserNameAsync(string userName)
    {
        var user = _dbContext.Set<User>().FirstOrDefault(u => u.UserName == userName);

        return Task.FromResult(user!);
    }

    public Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return Task.FromResult<IEnumerable<User>>(_dbContext.Set<User>().ToList());
    }
}
