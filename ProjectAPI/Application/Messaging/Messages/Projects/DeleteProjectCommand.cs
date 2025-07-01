using MediatR;
using MongoDB.Bson;

namespace Application.Messaging.Messages.Projects;

public record DeleteProjectsCommand(string Id) : IRequest;
