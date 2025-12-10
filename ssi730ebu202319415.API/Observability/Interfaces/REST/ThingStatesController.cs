using Microsoft.AspNetCore.Mvc;
using ssi730ebu202319415.API.Observability.Application.Internal.CommandServices;
using ssi730ebu202319415.API.Observability.Interfaces.REST.Resources;
using ssi730ebu202319415.API.Observability.Interfaces.REST.Transform;

namespace ssi730ebu202319415.API.Observability.Interfaces.REST;

[ApiController]
[Route("api/v1/thing-states")]
public class ThingStatesController(IThingStateCommandService commandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateThingStateResource resource)
    {
        var command = CreateThingStateCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        var resourceOut = ThingStateResourceFromEntityAssembler.ToResourceFromEntity(result!);
        return Created(string.Empty, resourceOut);
    }
}