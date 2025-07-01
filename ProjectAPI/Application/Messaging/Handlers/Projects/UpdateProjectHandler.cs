using Application.Contracts;
using Application.Messaging.Messages.Projects;
using Domain.Models;
using MediatR;
using MongoDB.Bson;

namespace Application.Messaging.Handlers.Projects;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IRepository<Project, string> _repository;

    public UpdateProjectHandler(IRepository<Project, string> repository)
    {
        _repository = repository;
    }

    public Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        => _repository.UpdateAsync(request.Project.Id, request.Project, cancellationToken);
}
