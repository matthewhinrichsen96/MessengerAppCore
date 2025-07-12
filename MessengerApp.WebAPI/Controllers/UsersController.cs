using Microsoft.AspNetCore.Mvc;
using MessengerApp.Services.Models.Users;
using MessengerApp.Services.Repositories;

namespace MessengerApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(
    ILogger<UsersController> logger,
    IUserRepository userRepository) : ControllerBase
{
    private readonly ILogger<UsersController> _logger = logger;

    [HttpGet(Name = "All")]
    [Route("All")]
    public async Task<IActionResult> Users()
    {
        try
        {
            var users = await userRepository.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet(Name = "GetUserById")]
    [Route("Id/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            var user = await userRepository.GetUserByIdAsync(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet(Name = "GetUserByUsername")]
    [Route("Username/{userName}")]
    public async Task<IActionResult> GetUserByUserName(string userName)
    {
        try
        {
            var users = await userRepository.GetUserByUserNameAsync(userName);
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete(Name = "DeleteUserById")]
    [Route("Delete/{id}")]
    public async Task<IActionResult> DeleteUserByUserId(int id)
    {
        try
        {
            await userRepository.DeleteUserAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateUser(Users user)
    {
        try
        {
            var newUser = await userRepository.CreateUserAsync(user);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [Route("GroupCreate")]
    public async Task<IActionResult> CreateUser(IEnumerable<Users> users)
    {
        try
        {
            foreach (var user in users)
            {
                await userRepository.CreateUserAsync(user);
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}