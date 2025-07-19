using MessengerApp.Services.Models.Teams;

namespace MessengerApp.Services.Repositories;

public interface ITeamRepository
{
    Task CreateTeam(Team team);

    Task UpdateTeam(Team team);

    Task<int> DeleteTeam(int teamId);

    Task<IEnumerable<Team?>> GetTeams();

    Task<Team?> GetTeam(int teamId);

    Task<Team?> GetTeamByName(string teamName);
}