using Application.Models;
using Application.Services;
using Common.Enums;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionsController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Subscription>))]
    public async Task<ActionResult<List<Subscription>>> GetList(CancellationToken cancellationToken)
    {
        var subscriptions = await _subscriptionService.GetListAsync(cancellationToken);

        return Ok(subscriptions);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Subscription))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Subscription>>> Get(int id, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionService.GetAsync(id, cancellationToken);

        return Ok(subscription);
    }

    [HttpGet("{type}/users")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    public async Task<ActionResult<List<Subscription>>> Get(SubscriptionType type, CancellationToken cancellationToken)
    {
        var users = await _subscriptionService.GetUsersBySubscriptionTypeAsync(type, cancellationToken);

        return Ok(users);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Subscription))]
    public async Task<ActionResult<List<Subscription>>> Create(SubscriptionModel subscription, CancellationToken cancellationToken)
    {
        var entity = await _subscriptionService.AddAsync(subscription, cancellationToken);

        return CreatedAtAction(nameof(Get), new { entity.Id }, entity);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Subscription>>> Update(SubscriptionModel subscription, CancellationToken cancellationToken)
    {
        await _subscriptionService.UpdateAsync(subscription, cancellationToken);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Subscription>>> Delete(int id, CancellationToken cancellationToken)
    {
        await _subscriptionService.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}
