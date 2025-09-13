using MessengerApp.Services.Models.Users;
using MessengerApp.Services.Models.Teams;
using Microsoft.EntityFrameworkCore;

namespace MessengerApp.Services.Data;

public class AppDbContext(IConfiguration configuration) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<User>? Users { get; set; }

    public DbSet<Team>? Teams { get; set; }
}
