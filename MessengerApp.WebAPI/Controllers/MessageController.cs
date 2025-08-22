using MessengerApp.Services.Interfaces;
using MessengerApp.Services.Models.Messages;
using Microsoft.AspNetCore.Mvc;
using MessengerApp.WebAPI.Filters;

namespace MessengerApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MessageController(IMessengerService messengerService) : ControllerBase
{
    [TypeFilter(typeof(ApiExceptionFilter))]
    [HttpPost("")]
    public Task<IActionResult> SendMessage(Message message)
    {
        messengerService.SendMessage(message);

        return Task.FromResult<IActionResult>(Ok());
    }

    [TypeFilter(typeof(ApiExceptionFilter))]
    [HttpGet("")]
    public async Task<IActionResult> GetMessages(string userId, string chatId)
    {
        var messages = await messengerService.GetMessages(userId, chatId);

        return Ok(messages);
    }
}