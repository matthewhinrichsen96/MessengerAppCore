namespace MessengerApp.Services.Models.Messages;

public class Message
{
    public required string ChatId { get; set; }

    public required string SenderId { get; set; }

    public required string Text { get; set; }

    public required string TimeStamp { get; set; }
}
