using Application.Contracts;
using Application.Messaging.Messages.Settings;
using Domain.Models;
using MediatR;

namespace Application.Messaging.Handlers.Settings;

public class CreateProjectHandler : IRequestHandler<CreateUserSettingsCommand>
{
    private readonly IRepository<UserSetting, string> _repository;

    public CreateProjectHandler(IRepository<UserSetting, string> repository)
    {
        _repository = repository;
    }

    public Task Handle(CreateUserSettingsCommand request, CancellationToken cancellationToken)
    {
        var settings = new UserSetting
        {
            UserId = request.UserId,
            Language = request.Language,
            Theme = request.Theme
        };

        return _repository.AddAsync(settings, cancellationToken);
    }
}
