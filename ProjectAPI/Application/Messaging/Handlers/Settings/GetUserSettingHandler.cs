using Application.Contracts;
using Application.Messaging.Messages.Settings;
using Domain.Models;
using MediatR;

namespace Application.Messaging.Handlers.Settings;

public class GetUserSettingsHandler : IRequestHandler<GetUserSettingsCommand, List<UserSetting>>
{
    private readonly IRepository<UserSetting, string> _repository;

    public GetUserSettingsHandler(IRepository<UserSetting, string> repository)
    {
        _repository = repository;
    }

    public Task<List<UserSetting>> Handle(GetUserSettingsCommand request, CancellationToken cancellationToken)
        => _repository.GetAsync(x => x.UserId == request.UserId, cancellationToken);
}
