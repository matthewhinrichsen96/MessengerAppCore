using MessengerApp.Services.Data;
using MessengerApp.Services.Models.Users;
using Npgsql;

namespace MessengerApp.Services.Repositories;

public class UserRepository(IConfiguration configuration) : IUserRepository
{
    private readonly IConfiguration _configuration = configuration;
    private readonly AppDbContext _dbContext = new(configuration);

    public async Task<Users> CreateUserAsync(Users user)
    {
        _dbContext.Set<Users>().Add(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<Users> UpdateUserAsync(Users user)
    {
       _dbContext.Set<Users>().Update(user);
       await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = _dbContext.Set<Users>().FirstOrDefault(u => u.UserId == userId);

        _dbContext.RemoveRange(user!);

        await _dbContext.SaveChangesAsync();
    }

    public Task<Users> GetUserByIdAsync(int userId)
    {
        var user = _dbContext.Set<Users>().FirstOrDefault(u => u.UserId == userId);

        return Task.FromResult(user!);
    }

    public Task<Users> GetUserByUserNameAsync(string userName)
    {
        var user = _dbContext.Set<Users>().FirstOrDefault(u => u.UserName == userName);

        return Task.FromResult(user!);
    }

    public Task<IEnumerable<Users>> GetAllUsersAsync()
    {
        return Task.FromResult<IEnumerable<Users>>(_dbContext.Set<Users>().ToList());
    }
} 