using Application.Contracts;
using Application.Messaging.Messages.Projects;
using Domain.Models;
using MediatR;
using MongoDB.Bson;

namespace Application.Messaging.Handlers.Projects;

public class GetProjectsHandler : IRequestHandler<GetProjectsCommand, List<Project>>
{
    private readonly IRepository<Project, string> _repository;

    public GetProjectsHandler(IRepository<Project, string> repository)
    {
        _repository = repository;
    }

    public Task<List<Project>> Handle(GetProjectsCommand request, CancellationToken cancellationToken)
        => _repository.GetAsync(x => x.UserId == request.UserId, cancellationToken);
}
