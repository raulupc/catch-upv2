namespace ssi730ebu202319415.API.Observability.Interfaces.REST.Resources;

public record ThingStateResource(
    int Id,
    string ThingSerialNumber,
    int CurrentOperationMode,
    decimal CurrentTemperature,
    decimal CurrentHumidity,
    DateTime CollectedAt);