using MessengerApp.Services.Models.Messages;

namespace MessengerApp.Services.Interfaces;

public interface IMessengerService
{
    public void SendMessage(Message message);

    public Task<List<Message?>> GetMessages(string senderId, string chatId);
}