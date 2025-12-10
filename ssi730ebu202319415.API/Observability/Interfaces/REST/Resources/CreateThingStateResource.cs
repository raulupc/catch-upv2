namespace ssi730ebu202319415.API.Observability.Interfaces.REST.Resources;

public record CreateThingStateResource(
    Guid ThingSerialNumber,
    int CurrentOperationMode,
    decimal CurrentTemperature,
    decimal CurrentHumidity,
    DateTime CollectedAt);