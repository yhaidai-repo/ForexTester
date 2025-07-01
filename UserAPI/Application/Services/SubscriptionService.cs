using Application.DataAccess;
using Application.Models;
using Common.Enums;
using Common.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly IApplicationDbContext _dbContext;

    public SubscriptionService(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Subscription> AddAsync(SubscriptionModel subscription, CancellationToken cancellationToken = default)
    {
        var entity = new Subscription
        {
            Type = subscription.Type,
            StartDate = subscription.StartDate,
            EndDate = subscription.EndDate
        };

        var entry = await _dbContext.Subscriptions.AddAsync(entity, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Subscriptions.FindAsync([id], cancellationToken)
            ?? throw new EntityNotFoundException<Subscription>(id);

        _dbContext.Subscriptions.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask<Subscription?> GetAsync(int id, CancellationToken cancellationToken = default)
        => await _dbContext.Subscriptions.FindAsync([id], cancellationToken) 
        ?? throw new EntityNotFoundException<Subscription>(id);

    public Task<List<Subscription>> GetListAsync(CancellationToken cancellationToken = default)
        => _dbContext.Subscriptions.AsNoTracking().ToListAsync(cancellationToken);

    public Task<List<User>> GetUsersBySubscriptionTypeAsync(SubscriptionType subscriptionType, CancellationToken cancellationToken = default)
        => _dbContext.Subscriptions
            .Where(x => x.Type == subscriptionType)
            .SelectMany(x => x.Users)
            .GroupBy(x => x.Id)
            .Select(x => x.First())
            .ToListAsync(cancellationToken);

    public async Task UpdateAsync(SubscriptionModel subscription, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Subscriptions.FindAsync([subscription.Id], cancellationToken)
            ?? throw new EntityNotFoundException<Subscription>(subscription.Id);

        entity.Type = subscription.Type;
        entity.StartDate = subscription.StartDate;
        entity.EndDate = subscription.EndDate;

        _dbContext.Subscriptions.Update(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
