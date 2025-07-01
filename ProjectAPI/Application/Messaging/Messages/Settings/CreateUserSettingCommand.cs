using Application.Messaging.Contracts;
using Domain.Enums;
using MediatR;

namespace Application.Messaging.Messages.Settings;

public record CreateUserSettingsCommand(string Id, int UserId, Language Language, Theme Theme) : IHaveUserEntity, IRequest;
