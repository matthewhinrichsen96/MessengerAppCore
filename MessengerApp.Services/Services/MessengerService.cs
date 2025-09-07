using System.Text.Json;
using MessengerApp.Services.Interfaces;
using MessengerApp.Services.Models.Messages;
using StackExchange.Redis;


namespace MessengerApp.Services.Services;

public class MessengerService(ILogger<MessengerService> logger) : IMessengerService
{
    private static readonly ConnectionMultiplexer Redis = ConnectionMultiplexer.Connect("localhost");
    private readonly IDatabase _db = Redis.GetDatabase();
    private readonly ILogger<MessengerService> _logger = logger;

    public void SendMessage(Message message)
    {
        var serializedMessage = JsonSerializer.Serialize(message);
        var redisKey = $"chat:{message.senderId}:{message.chatId}";
        DateTime dt = DateTime.Parse(message.timeStamp, null, System.Globalization.DateTimeStyles.RoundtripKind);
        double score = new DateTimeOffset(dt).ToUnixTimeSeconds();

        _db.SortedSetAdd(redisKey, serializedMessage, score);
        _logger.LogInformation("Sent message to {MessageSenderId}:{MessageChatId}", message.senderId, message.chatId);
    }

    public async Task<List<Message?>> GetMessages(string senderId, string chatId)
    {
        var redisKey = $"chat:{senderId}:{chatId}";

        var results = await _db.SortedSetRangeByRankAsync(redisKey, 0, -1, Order.Ascending);

        var messages = results
            .Select(entry =>
            {
                try
                {
                    return JsonSerializer.Deserialize<Message>(entry!);
                }
                catch (JsonException ex)
                {
                    _logger.LogWarning(ex, $"Invalid JSON in Redis for key {redisKey}: {entry}");
                    Console.WriteLine(ex.InnerException);
                    return null;
                }
            })
            .Where(msg => msg != null)!
            .ToList();

        _logger.LogInformation("Received {MessageCount} messages from {SenderId}", messages.Count, senderId);

        return messages;
    }
}
