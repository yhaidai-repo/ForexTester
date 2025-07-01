using Application.Contracts;
using Application.Messaging.Contracts;
using Common.Exceptions;
using Domain.Models.Integration;
using MediatR;

namespace Application.Behaviours;

public class HasUserBehaviour<TRequest, TResponse>(IUsersApiClient apiClient) 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest, IHaveUserEntity
{
    private readonly IUsersApiClient _apiClient = apiClient;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _ = await _apiClient.GetUserAsync(request.UserId, cancellationToken)
            ?? throw new EntityNotFoundException<User>(request.UserId);

        return await next(cancellationToken);
    }
}
