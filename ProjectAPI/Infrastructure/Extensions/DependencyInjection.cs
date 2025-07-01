using Application.Behaviours;
using Application.Contracts;
using Application.DI;
using Application.Extensions;
using Domain.Models;
using Infrastructure.ApiClients;
using Infrastructure.ConfigurationOptions;
using Infrastructure.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Reflection;

namespace Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection("MongoDb").Get<MongoConfiguration>();

        var client = new MongoClient(options!.ConnectionString);
        var database = client.GetDatabase(options!.Database);

        services
            .AddSingleton<IMongoClient>(client)
            .AddSingleton(database)
            .AddSingleton(x => database.GetCollection<UserSetting>(CollectionNames.UserSettings))
            .AddSingleton(x => database.GetCollection<Project>(CollectionNames.Projects))
            .AddScoped<IRepository<UserSetting, string>, Repository<UserSetting, string>>()
            .AddScoped<IRepository<Project, string>, Repository<Project, string>>();

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var userApiUrl = configuration.GetValue<string>("UsersApi:Url")
            ?? throw new ArgumentNullException("User API URL config not found!");

        services
            .AddApplicationMediatR()
            .AddScoped<IUsersApiClient, UsersApiClient>()
            .AddHttpClient<IUsersApiClient, UsersApiClient>(httpClient 
                => httpClient.BaseAddress = new Uri(userApiUrl));

        return services;
    }
}
