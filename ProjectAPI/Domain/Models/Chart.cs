using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models;

public record Chart
{
    [BsonElement("symbol")]
    public string Symbol { get; init; } = default!;

    [BsonElement("timeframe")]
    public string Timeframe { get; init; } = default!;

    [BsonElement("indicators")]
    public List<Indicator> Indicators { get; init; } = [];
}
