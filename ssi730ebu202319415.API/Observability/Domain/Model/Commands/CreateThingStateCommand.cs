namespace ssi730ebu202319415.API.Observability.Domain.Model.Commands;

public record CreateThingStateCommand(
    Guid ThingSerialNumber,
    int CurrentOperationMode,
    decimal CurrentTemperature,
    decimal CurrentHumidity,
    DateTime CollectedAt);