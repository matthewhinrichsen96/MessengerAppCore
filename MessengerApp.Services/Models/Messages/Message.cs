namespace MessengerApp.Services.Models.Messages;

public class Message
{
    public string chatId { get; set; }

    public string senderId { get; set; }

    public string text { get; set; }

    public int timeStamp { get; set; }
}