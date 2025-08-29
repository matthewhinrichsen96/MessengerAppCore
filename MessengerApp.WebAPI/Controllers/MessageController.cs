using MessengerApp.Services.Interfaces;
using MessengerApp.Services.Models.Messages;
using Microsoft.AspNetCore.Mvc;
using MessengerApp.WebAPI.Filters;

namespace MessengerApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MessageController(
    IMessengerService messengerService) : ControllerBase
{
    [TypeFilter(typeof(ApiExceptionFilter))]
    [HttpPost("")]
    public Task<IActionResult> SendMessage(Message message)
    {
        try
        {
            messengerService.SendMessage(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }

        return Task.FromResult<IActionResult>(Ok("Message Sent"));
    }

    [TypeFilter(typeof(ApiExceptionFilter))]
    [HttpGet("")]
    public async Task<IActionResult> GetMessages(string chatId, string userId)
    {
        try
        {
            var messages = await messengerService.GetMessages(userId, chatId);

            return Ok(messages);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);

            return BadRequest("Something went wrong");
        }
    }
}
