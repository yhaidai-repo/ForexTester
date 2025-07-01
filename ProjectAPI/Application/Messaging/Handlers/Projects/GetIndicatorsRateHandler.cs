using Application.Contracts;
using Application.Helpers;
using Application.Messaging.Messages.Projects;
using Domain.Models;
using MediatR;

namespace Application.Messaging.Handlers.Projects;

public class GetIndicatorsRateHandler : IRequestHandler<GetIndicatorsRateCommand, List<IndicatorRate>>
{
    private readonly IUsersApiClient _apiClient;
    private readonly IRepository<Project, string> _repository;

    public GetIndicatorsRateHandler(IUsersApiClient apiClient, IRepository<Project, string> repository)
    {
        _apiClient = apiClient;
        _repository = repository;
    }

    public async Task<List<IndicatorRate>> Handle(GetIndicatorsRateCommand request, CancellationToken cancellationToken)
    {
        var users = await _apiClient.GetUsersBySubscriptionType(request.Type, cancellationToken);

        if (users is null)
        {
            return [];
        }

        var ids = users.Select(x => x.Id).ToList();
        var projects = await _repository.GetAsync(x => ids.Contains(x.UserId), cancellationToken);

        if (projects is null)
        {
            return [];
        }

        return ProjectsHelper.GetTop3Indicators([.. projects.SelectMany(x => x.Charts).SelectMany(x => x.Indicators)]);
    }
}
