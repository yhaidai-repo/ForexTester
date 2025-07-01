using Domain.Models;
using MediatR;

namespace Application.Messaging.Messages.Settings;

public record GetUserSettingsCommand(int UserId) : IRequest<List<UserSetting>>;