using Application.Contracts;
using Application.Messaging.Messages.Settings;
using Domain.Models;
using MediatR;

namespace Application.Messaging.Handlers.Settings;

public class DeleteProjectHandler : IRequestHandler<DeleteUserSettingsCommand>
{
    private readonly IRepository<UserSetting, string> _repository;

    public DeleteProjectHandler(IRepository<UserSetting, string> repository)
    {
        _repository = repository;
    }

    public Task Handle(DeleteUserSettingsCommand request, CancellationToken cancellationToken)
    {
        return _repository.DeleteAsync(request.Id, cancellationToken);
    }
}
