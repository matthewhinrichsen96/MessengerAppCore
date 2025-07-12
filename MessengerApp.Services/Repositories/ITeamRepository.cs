using MessengerApp.Services.Models.Teams;

namespace MessengerApp.Services.Repositories;

public interface ITeamRepository
{
    Task CreateTeam(Teams team);

    Task UpdateTeam(Teams team);

    Task DeleteTeam(int teamId);

    Task<IEnumerable<Teams>> GetTeams();

    Task<Teams> GetTeam(int teamId);

    Task<Teams> GetTeamByName(string teamName);
}