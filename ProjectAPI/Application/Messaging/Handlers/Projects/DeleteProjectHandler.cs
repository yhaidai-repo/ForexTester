using Application.Contracts;
using Application.Messaging.Messages.Projects;
using Domain.Models;
using MediatR;

namespace Application.Messaging.Handlers.Projects;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectsCommand>
{
    private readonly IRepository<Project, string> _repository;

    public DeleteProjectHandler(IRepository<Project, string> repository)
    {
        _repository = repository;
    }

    public Task Handle(DeleteProjectsCommand request, CancellationToken cancellationToken)
        => _repository.DeleteAsync(request.Id, cancellationToken);
}
