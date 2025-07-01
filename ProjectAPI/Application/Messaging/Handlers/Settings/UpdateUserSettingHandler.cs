using Application.Contracts;
using Application.Messaging.Messages.Settings;
using Common.Exceptions;
using Domain.Models;
using MediatR;

namespace Application.Messaging.Handlers.Settings;

public class UpdateUserSettingsHandler : IRequestHandler<UpdateUserSettingsCommand>
{
    private readonly IRepository<UserSetting, string> _repository;

    public UpdateUserSettingsHandler(IRepository<UserSetting, string> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateUserSettingsCommand request, CancellationToken cancellationToken)
    {
        var original = await _repository.GetAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException<UserSetting>(request.Id);

        var settings = new UserSetting
        {
            Language = request.Language,
            Theme = request.Theme,
            UserId = original.UserId 
        };

        await _repository.UpdateAsync(request.Id, settings, cancellationToken);
    }
}
