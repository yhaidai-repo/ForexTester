using Application.DataAccess;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Subscription> Subscriptions { get; set; }
}
