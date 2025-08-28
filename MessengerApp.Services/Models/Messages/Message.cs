namespace MessengerApp.Services.Models.Messages;

public class Message
{
    required
    public string chatId
    { get; set; }

    required
    public string senderId
    { get; set; }

    required
    public string text
    { get; set; }

    public string timeStamp { get; set; }
}
