using Domain.Contracts;
using System.Linq.Expressions;

namespace Application.Contracts;

public interface IRepository<T, TId> where T : IIdEntity<TId>
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> GetAsync(TId id, CancellationToken cancellationToken = default);
    Task<List<T>> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task UpdateAsync(TId id, T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TId id, CancellationToken cancellationToken = default);
}
