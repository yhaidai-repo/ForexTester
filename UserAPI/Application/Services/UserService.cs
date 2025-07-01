using Application.DataAccess;
using Application.Models;
using Common.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IApplicationDbContext _dbContext;

    public UserService(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<User>> GetListAsync(CancellationToken cancellationToken = default)
        => _dbContext.Users.Include(x => x.Subscription).AsNoTracking().ToListAsync(cancellationToken);

    public async ValueTask<User?> GetAsync(int id, CancellationToken cancellationToken = default)
        => await _dbContext.Users.Include(x => x.Subscription).FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
        ?? throw new EntityNotFoundException<User>(id);

    public async Task UpdateAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Users.FindAsync([user.Id], cancellationToken)
            ?? throw new EntityNotFoundException<User>(user.Id);

        entity.Name = user.Name;
        entity.Email = user.Email;
        entity.SubscriptionId = user.SubscriptionId;

        if (user.SubscriptionId.HasValue)
        {
            entity.Subscription = await _dbContext.Subscriptions.FindAsync([user.SubscriptionId], cancellationToken);
        }

        _dbContext.Users.Update(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<User> AddAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        var entity = new User
        {
            Name = user.Name,
            Email = user.Email,
            SubscriptionId = user.SubscriptionId
        };

        if (user.SubscriptionId.HasValue)
        {
            entity.Subscription = await _dbContext.Subscriptions.FindAsync([user.SubscriptionId], cancellationToken);
        }

        var entry = await _dbContext.Users.AddAsync(entity, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Users.FindAsync([id], cancellationToken)
            ?? throw new EntityNotFoundException<User>(id);

        _dbContext.Users.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
