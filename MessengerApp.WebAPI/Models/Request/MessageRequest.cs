namespace MessengerApp.WebAPI.Models.Request;

public class MessageRequest
{
    public required string ChatId { get; set; }

    public required string UserId { get; set; }
}
