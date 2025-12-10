using ssi730ebu202319415.API.Inventory.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Inventory.Interfaces.REST.Resources;

namespace ssi730ebu202319415.API.Inventory.Interfaces.REST.Transform;

public static class ThingResourceFromEntityAssembler
{
    public static ThingResource ToResourceFromEntity(Thing entity)
        => new(entity.Id, entity.SerialNumberValue, entity.Model, entity.OperationMode.ToString(),
            entity.MaximumTemperatureThreshold, entity.MinimumHumidityThreshold);
}