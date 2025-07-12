using Microsoft.AspNetCore.Mvc;
using MessengerApp.Services.Models.Teams;
using MessengerApp.Services.Repositories;

namespace MessengerApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TeamsController(
    ILogger<TeamsController> logger,
    ITeamRepository teamRepository) : ControllerBase
{
    private readonly ILogger<TeamsController> _logger = logger;

    [HttpGet(Name = "AllTeams")]
    [Route("AllTeams")]
    public async Task<IActionResult> teams()
    {
        try
        {
            var teams = await teamRepository.GetTeams();
            return Ok(teams);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet(Name = "GetTeamById")]
    [Route("Id/{id}")]
    public async Task<IActionResult> GetteamById(int id)
    {
        try
        {
            var team = await teamRepository.GetTeam(id);
            return Ok(team);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet(Name = "GetTeamByteamname")]
    [Route("TeamName/{teamName}")]
    public async Task<IActionResult> GetTeamByteamName(string teamName)
    {
        try
        {
            var teams = await teamRepository.GetTeamByName(teamName);
            return Ok(teams);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete(Name = "DeleteTeamById")]
    [Route("Delete/{id}")]
    public async Task<IActionResult> DeleteteamByteamId(int id)
    {
        try
        {
            await teamRepository.DeleteTeam(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Createteam(Teams team)
    {
        try
        {
            await teamRepository.CreateTeam(team);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [Route("GroupCreate")]
    public async Task<IActionResult> Createteam(IEnumerable<Teams> teams)
    {
        try
        {
            foreach (var team in teams)
            {
                await teamRepository.CreateTeam(team);
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}