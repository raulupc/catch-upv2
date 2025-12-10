using ssi730ebu202319415.API.Observability.Domain.Model.Commands;
using ssi730ebu202319415.API.Observability.Domain.Model.ValueObjects;
using ssi730ebu202319415.API.Shared.Domain.Model;

namespace ssi730ebu202319415.API.Observability.Domain.Model.Aggregates;

public partial class ThingState : AuditableEntity<int>
{
    public ThingSerialNumber ThingSerialNumber { get; private set; } = new();
    public int CurrentOperationMode { get; private set; }
    public decimal CurrentTemperature { get; private set; }
    public decimal CurrentHumidity { get; private set; }
    public DateTime CollectedAt { get; private set; }

    public ThingState() { }

    public ThingState(CreateThingStateCommand command)
    {
        ThingSerialNumber = new ThingSerialNumber(command.ThingSerialNumber);
        CurrentOperationMode = command.CurrentOperationMode;
        CurrentTemperature = command.CurrentTemperature;
        CurrentHumidity = command.CurrentHumidity;
        CollectedAt = command.CollectedAt;
    }

    public string ThingSerialNumberValue => ThingSerialNumber.Value.ToString();
}