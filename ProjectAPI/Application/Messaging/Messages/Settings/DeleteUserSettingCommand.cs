using MediatR;
using MongoDB.Bson;

namespace Application.Messaging.Messages.Settings;

public record DeleteUserSettingsCommand(string Id) : IRequest;
