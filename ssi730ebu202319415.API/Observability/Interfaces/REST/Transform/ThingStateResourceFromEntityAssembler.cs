using ssi730ebu202319415.API.Observability.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Observability.Interfaces.REST.Resources;

namespace ssi730ebu202319415.API.Observability.Interfaces.REST.Transform;

public static class ThingStateResourceFromEntityAssembler
{
    public static ThingStateResource ToResourceFromEntity(ThingState entity)
        => new(entity.Id, entity.ThingSerialNumberValue, entity.CurrentOperationMode,
            entity.CurrentTemperature, entity.CurrentHumidity, entity.CollectedAt);
}