using Microsoft.AspNetCore.Mvc;
using MessengerApp.Services.Models.Users;
using MessengerApp.Services.Repositories;
using MessengerApp.WebAPI.Filters;

namespace MessengerApp.WebAPI.Controllers;

[TypeFilter(typeof(ApiExceptionFilter))]
[ApiController]
[Route("api/[controller]")]
public class UsersController(
    ILogger<UsersController> logger,
    IUserRepository userRepository) : ControllerBase
{

    [HttpGet("")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userRepository.GetAllUsersAsync();

        return Ok(users);
    }

    [HttpGet("by-id/{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userRepository.GetUserByIdAsync(id);

        return Ok(user);
    }

    [HttpGet( "by-username/{userName}")]
    public async Task<IActionResult> GetUserByUserName(string userName)
    {
        var users = await userRepository.GetUserByUserNameAsync(userName);

        return Ok(users);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUserByUserId(int id)
    {
        await userRepository.DeleteUserAsync(id);

        return NoContent();
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateUser(User user)
    {
        var newUser = await userRepository.CreateUserAsync(user);

        return CreatedAtAction(nameof(GetUserById), new {id = user.UserId }, newUser);
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> CreateMultipleUsers(IEnumerable<User> users)
    {
        var createdUsers = new List<User>();

        foreach (var user in users)
        {
            var createdUser = await userRepository.CreateUserAsync(user);
            createdUsers.Add(createdUser);
        }

        return Created("", createdUsers);
    }
}