using Common.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Subscription
{
    public int Id { get; set; }
    public required SubscriptionType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [JsonIgnore]
    public ICollection<User> Users { get; set; } = [];
}