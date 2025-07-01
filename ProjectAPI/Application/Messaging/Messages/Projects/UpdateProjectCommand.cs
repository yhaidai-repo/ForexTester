using Application.Messaging.Contracts;
using Domain.Models;
using MediatR;

namespace Application.Messaging.Messages.Projects;

public record UpdateProjectCommand(Project Project) : IHaveUserEntity, IRequest
{
    public int UserId => Project.UserId;
}