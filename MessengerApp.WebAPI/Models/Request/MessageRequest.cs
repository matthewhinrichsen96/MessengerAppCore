namespace MessengerApp.WebAPI.Models.Request.MessageRequest;

public class MessageRequest
{
    required public string chatId { get; set; }

    required public string userId { get; set; }
}
