using Domain.Contracts;
using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models;

public record UserSetting : IIdEntity<string>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; }
    [BsonElement("userId")]
    public required int UserId { get; init; }
    [BsonElement("language")]
    public Language Language { get; init; }
    [BsonElement("theme")]
    public Theme Theme { get; init; }
}
