using Domain.Models;
using MediatR;

namespace Application.Messaging.Messages.Projects;

public record GetProjectsCommand(int UserId) : IRequest<List<Project>>;