using Application.DataAccess;
using Application.Services;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(contextOptionsBuilder => contextOptionsBuilder.UseNpgsql(configuration.GetConnectionString("Default"), npgsqlOptionsBuilder =>
        {
            npgsqlOptionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
        }));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISubscriptionService, SubscriptionService>();

        return services;
    }
}
