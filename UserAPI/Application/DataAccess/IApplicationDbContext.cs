using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccess;

public interface IApplicationDbContext : IDisposable, IAsyncDisposable
{
    DbSet<User> Users { get; }
    DbSet<Subscription> Subscriptions { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
} 
