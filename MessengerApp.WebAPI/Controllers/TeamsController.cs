using Microsoft.AspNetCore.Mvc;
using MessengerApp.Services.Models.Teams;
using MessengerApp.Services.Repositories;
using MessengerApp.WebAPI.Filters;

namespace MessengerApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TeamsController(
    ITeamRepository teamRepository) : ControllerBase
{
    [TypeFilter(typeof(ApiExceptionFilter))]
    [HttpGet("")]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await teamRepository.GetTeams();

        return Ok(teams);
    }

    [TypeFilter(typeof(ApiExceptionFilter))]
    [HttpGet("by-id/{id}")]
    public async Task<IActionResult> GetTeamById(int id)
    {
        var team = await teamRepository.GetTeam(id);

        return Ok(team);
    }

    [TypeFilter(typeof(ApiExceptionFilter))]
    [HttpGet("by-name/{teamName}")]
    public async Task<IActionResult> GetTeamByTeamName(string teamName)
    {
        var team = await teamRepository.GetTeamByName(teamName);

        return Ok(team);
    }

    [TypeFilter(typeof(ApiExceptionFilter))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeamById(int id)
    {
        await teamRepository.DeleteTeam(id);

        return Ok("Team deleted");
    }

    [TypeFilter(typeof(ApiExceptionFilter))]
    [HttpPost("")]
    public async Task<IActionResult> CreateTeam([FromBody] Team? team)
    {
        await teamRepository.CreateTeam(team);

        return CreatedAtAction(nameof(GetTeamById), new {id = team.TeamId }, team);
    }

    [TypeFilter(typeof(ApiExceptionFilter))]
    [HttpPost("Batch")]
    public async Task<IActionResult> CreateMultipleTeams([FromBody] IEnumerable<Team> teams)
    {
        await Task.WhenAll(teams.Select(teamRepository.CreateTeam));

        return Ok();
    }
}