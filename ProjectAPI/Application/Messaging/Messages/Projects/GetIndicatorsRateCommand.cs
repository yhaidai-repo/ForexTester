using Common.Enums;
using Domain.Models;
using MediatR;

namespace Application.Messaging.Messages.Projects;

public record GetIndicatorsRateCommand(SubscriptionType Type) : IRequest<List<IndicatorRate>>;
