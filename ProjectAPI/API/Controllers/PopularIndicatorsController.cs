using Application.Messaging.Messages.Projects;
using Common.Enums;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
public class PopularIndicatorsController : Controller
{
    private readonly IMediator _mediator;

    public PopularIndicatorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{type}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IndicatorRate>))]
    public async Task<ActionResult> GetTopIndicatorsBySubscriptionType(SubscriptionType type, CancellationToken cancellationToken)
    {
        var indicators = await _mediator.Send(new GetIndicatorsRateCommand(type), cancellationToken);

        return Ok(indicators);
    }
}
