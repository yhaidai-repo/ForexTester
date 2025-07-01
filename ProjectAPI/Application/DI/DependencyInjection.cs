using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}