using Application.Contracts;
using Domain.Contracts;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess;

public class Repository<T, TId> : IRepository<T, TId> where T : IIdEntity<TId>
{
    private readonly static FilterDefinitionBuilder<T> Filter = Builders<T>.Filter;

    protected readonly IMongoCollection<T> _collection;

    public Repository(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    public Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);

    public Task<List<T>> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        var filter = Filter.Where(expression);

        return _collection.Find(filter).ToListAsync(cancellationToken);
    }

    public Task<T> GetAsync(TId id, CancellationToken cancellationToken = default)
    {
        var filter = Filter.Eq(x => x.Id, id);

        return _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
    }

    public Task UpdateAsync(TId id, T entity, CancellationToken cancellationToken = default)
    {
        var filter = Filter.Eq(x => x.Id, id);

        return _collection.ReplaceOneAsync(filter, entity, cancellationToken: cancellationToken);
    }

    public Task DeleteAsync(TId id, CancellationToken cancellationToken = default)
    {
        var filter = Filter.Eq(x => x.Id, id);

        return _collection.DeleteOneAsync(filter, cancellationToken: cancellationToken);
    }
}
