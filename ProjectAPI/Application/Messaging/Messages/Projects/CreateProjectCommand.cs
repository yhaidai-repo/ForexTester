using Application.Messaging.Contracts;
using Domain.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Messaging.Messages.Projects;

public record CreateProjectCommand(Project Project) : IHaveUserEntity, IRequest
{
    [JsonIgnore]
    public int UserId => Project.UserId;
}
