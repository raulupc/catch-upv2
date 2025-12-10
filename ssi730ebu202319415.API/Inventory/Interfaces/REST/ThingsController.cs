using Microsoft.AspNetCore.Mvc;
using ssi730ebu202319415.API.Inventory.Application.Internal.CommandServices;
using ssi730ebu202319415.API.Inventory.Domain.Repositories;
using ssi730ebu202319415.API.Inventory.Interfaces.REST.Resources;
using ssi730ebu202319415.API.Inventory.Interfaces.REST.Transform;

namespace ssi730ebu202319415.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/things")]
public class ThingsController(IThingCommandService commandService, IThingRepository repository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateThing([FromBody] CreateThingResource resource)
    {
        var command = CreateThingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var thing = await commandService.Handle(command);
        var result = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing!);
        return CreatedAtAction(nameof(GetThingById), new { id = result.Id }, result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetThingById(int id)
    {
        var thing = await repository.FindByIdAsync(id);
        if (thing == null) return NotFound();
        return Ok(ThingResourceFromEntityAssembler.ToResourceFromEntity(thing));
    }
}