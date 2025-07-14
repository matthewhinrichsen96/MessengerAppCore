using MessengerApp.Services.Models.Users;
using MessengerApp.Services.Models.Teams;
using Microsoft.EntityFrameworkCore;

namespace MessengerApp.Services.Data;

public class AppDbContext(IConfiguration configuration) : DbContext
{
    protected readonly IConfiguration _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Team> Teams { get; set; }
}
