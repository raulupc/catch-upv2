using ssi730ebu202319415.API.Inventory.Domain.Model.Commands;
using ssi730ebu202319415.API.Inventory.Interfaces.REST.Resources;

namespace ssi730ebu202319415.API.Inventory.Interfaces.REST.Transform;

public static class CreateThingCommandFromResourceAssembler
{
    public static CreateThingCommand ToCommandFromResource(CreateThingResource resource)
        => new(resource.Model, resource.MaximumTemperatureThreshold, resource.MinimumHumidityThreshold);
}