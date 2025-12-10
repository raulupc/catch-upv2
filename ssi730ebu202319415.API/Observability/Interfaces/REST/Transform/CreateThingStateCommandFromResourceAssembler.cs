using ssi730ebu202319415.API.Observability.Domain.Model.Commands;
using ssi730ebu202319415.API.Observability.Interfaces.REST.Resources;

namespace ssi730ebu202319415.API.Observability.Interfaces.REST.Transform;

public static class CreateThingStateCommandFromResourceAssembler
{
    public static CreateThingStateCommand ToCommandFromResource(CreateThingStateResource resource)
        => new(resource.ThingSerialNumber, resource.CurrentOperationMode, resource.CurrentTemperature,
            resource.CurrentHumidity, resource.CollectedAt);
}