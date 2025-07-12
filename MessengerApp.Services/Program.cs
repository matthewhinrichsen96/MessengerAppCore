using MessengerApp.Services;
using Microsoft.EntityFrameworkCore;
using MessengerApp.Services.Data;


var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

var host = builder.Build();
host.Run();
