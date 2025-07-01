using Application.Contracts;
using Application.Messaging.Messages.Projects;
using Domain.Models;
using MediatR;

namespace Application.Messaging.Handlers.Projects;

public class CreateProjectHandler : IRequestHandler<CreateProjectCommand>
{
    private readonly IRepository<Project, string> _repository;

    public CreateProjectHandler(IRepository<Project, string> repository)
    {
        _repository = repository;
    }

    public Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        => _repository.AddAsync(request.Project, cancellationToken);
}
