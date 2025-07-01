using Common.Enums;

namespace Domain.Models.Integration;

public record Subscription(int Id, SubscriptionType Type, DateTime StartDate, DateTime EndDate);
