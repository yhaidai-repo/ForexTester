using Application.Contracts;
using Common.Enums;
using Domain.Models.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ApiClients;

internal class UsersApiClient(HttpClient httpClient) : IUsersApiClient
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<User?> GetUserAsync(int id, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"users/{id}", cancellationToken);

        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<User>(cancellationToken)
            : default;
    }

    public Task<List<User>?> GetUsersBySubscriptionType(SubscriptionType type, CancellationToken cancellationToken = default)
        => _httpClient.GetFromJsonAsync<List<User>>($"subscriptions/{type}/users", cancellationToken);
}
