using MessengerApp.Services.Data;
using MessengerApp.Services.Models.Teams;

namespace MessengerApp.Services.Repositories;

public class TeamRepository(IConfiguration configuration) : ITeamRepository
{
    private readonly IConfiguration _configuration = configuration;
    private readonly AppDbContext _dbContext = new(configuration);

    public Task CreateTeam(Team team)
    {
        _dbContext.Teams.Add(team);

        return _dbContext.SaveChangesAsync();
    }

    public Task UpdateTeam(Team team)
    {
        _dbContext.Teams.Update(team);

        return _dbContext.SaveChangesAsync();
    }

    public Task DeleteTeam(int teamId)
    {
        var team = _dbContext.Set<Team>().FirstOrDefault(t => t.TeamId == teamId);
        _dbContext.Teams.Remove(team!);

        return _dbContext.SaveChangesAsync();
    }

    public Task<IEnumerable<Team>> GetTeams()
    {
        return Task.FromResult<IEnumerable<Team>>(_dbContext.Set<Team>().ToList());
    }

    public Task<Team> GetTeam(int teamId)
    {
        var team = _dbContext.Set<Team>().FirstOrDefault(t => t.TeamId == teamId);

        return Task.FromResult(team!);
    }

    public Task<Team> GetTeamByName(string teamName)
    {
        var team = _dbContext.Set<Team>().FirstOrDefault(t => t.Name == teamName);

        return Task.FromResult(team!);
    }
}