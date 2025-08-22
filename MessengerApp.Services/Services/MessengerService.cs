using System.Text.Json;
using MessengerApp.Services.Interfaces;
using MessengerApp.Services.Models.Messages;
using NRedisStack;
using NRedisStack.RedisStackCommands;
using NRedisStack.Search;
using StackExchange.Redis;


namespace MessengerApp.Services.Services;

public class MessengerService : IMessengerService
{
    private static readonly ConnectionMultiplexer Redis = ConnectionMultiplexer.Connect("localhost");
    private readonly IDatabase _db = Redis.GetDatabase();

    public void SendMessage(Message message)
    {
        var serializedMessage = JsonSerializer.Serialize(message);
        var redisKey = $"chat:{message.senderId}:{message.chatId}";

        _db.SortedSetAdd(redisKey, serializedMessage, message.timeStamp);
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
                    //_logger.LogWarning(ex, $"Invalid JSON in Redis for key {redisKey}: {entry}");
                    return null;
                }
            })
            .Where(msg => msg != null)!
            .ToList();

        return messages;
    }
}