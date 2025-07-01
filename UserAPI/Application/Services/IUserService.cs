using Application.Models;
using Domain.Entities;

namespace Application.Services;

public interface IUserService
{
    Task<List<User>> GetListAsync(CancellationToken cancellationToken = default);
    ValueTask<User?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(UserModel user, CancellationToken cancellationToken = default);
    Task<User> AddAsync(UserModel user, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
