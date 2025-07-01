using Domain.Enums;
using MediatR;

namespace Application.Messaging.Messages.Settings;

public record UpdateUserSettingsCommand(string Id, Language Language, Theme Theme) : IRequest;