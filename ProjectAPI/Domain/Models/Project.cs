using Domain.Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models;

public class Project : IIdEntity<string>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = default!;
    [BsonElement("UserId")]
    public required int UserId { get; init; }

    [BsonElement("name")]
    public required string Name { get; init; }

    [BsonElement("charts")]
    public List<Chart> Charts { get; init; } = [];
}
