using MessengerApp.Services.Data;
using MessengerApp.Services.Models.Teams;
using Microsoft.EntityFrameworkCore;

namespace MessengerApp.Services.Repositories;

public class TeamRepository(AppDbContext dbContext) : ITeamRepository
{

    public Task CreateTeam(Team team)
    {
        _ = dbContext.Teams.Add(team);

        return dbContext.SaveChangesAsync();
    }

    public Task UpdateTeam(Team team)
    {
        _ = dbContext.Teams.Update(team);

        return dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteTeam(int teamId)
    {
        var team = await dbContext.Teams.FirstOrDefaultAsync(t => t.TeamId == teamId);

        _ = team ?? throw new InvalidOperationException($"Team with ID {teamId} not found.");

        _ = dbContext.Teams.Remove(team);

        return await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Team?>> GetTeams()
    {
        return await dbContext.Teams.ToListAsync();
    }

    public async Task<Team?> GetTeam(int teamId)
    {
        return await dbContext.Teams.FirstOrDefaultAsync(t => t.TeamId == teamId);
    }

    public async Task<Team?> GetTeamByName(string teamName)
    {
        return await dbContext.Teams.FirstOrDefaultAsync(t => t.Name == teamName);
    }
}
