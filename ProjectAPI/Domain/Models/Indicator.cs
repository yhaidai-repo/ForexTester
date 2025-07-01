using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models;

public record Indicator
{
    [BsonElement("name")]
    public string Name { get; init; } = default!;

    [BsonElement("parameters")]
    public string Parameters { get; init; } = default!;
}