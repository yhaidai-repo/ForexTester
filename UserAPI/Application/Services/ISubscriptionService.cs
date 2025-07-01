using Application.Models;
using Common.Enums;
using Domain.Entities;

namespace Application.Services;

public interface ISubscriptionService
{
    Task<List<Subscription>> GetListAsync(CancellationToken cancellationToken = default);
    Task<List<User>> GetUsersBySubscriptionTypeAsync(SubscriptionType subscriptionType, CancellationToken cancellationToken = default);
    ValueTask<Subscription?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(SubscriptionModel subscription, CancellationToken cancellationToken = default);
    Task<Subscription> AddAsync(SubscriptionModel subscription, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
