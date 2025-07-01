using Common.Enums;

namespace Application.Models;

public record SubscriptionModel(int Id, SubscriptionType Type, DateTime StartDate, DateTime EndDate);
