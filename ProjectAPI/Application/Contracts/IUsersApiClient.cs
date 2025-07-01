using Common.Enums;
using Domain.Models.Integration;

namespace Application.Contracts;

public interface IUsersApiClient
{
    Task<User?> GetUserAsync(int id, CancellationToken cancellationToken = default);
    Task<List<User>?> GetUsersBySubscriptionType(SubscriptionType type, CancellationToken cancellationToken = default);
}
