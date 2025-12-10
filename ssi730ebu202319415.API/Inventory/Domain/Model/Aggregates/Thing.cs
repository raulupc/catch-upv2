using ssi730ebu202319415.API.Inventory.Domain.Model.Commands;
using ssi730ebu202319415.API.Inventory.Domain.Model.Enumerations;
using ssi730ebu202319415.API.Inventory.Domain.Model.ValueObjects;
using ssi730ebu202319415.API.Shared.Domain.Model;

namespace ssi730ebu202319415.API.Inventory.Domain.Model.Aggregates;

public partial class Thing : AuditableEntity<int>
{
    public SerialNumber SerialNumber { get; private set; } = new();
    public string Model { get; private set; } = string.Empty;
    public EOperationMode OperationMode { get; private set; } = EOperationMode.ScheduleDriven;
    public decimal MaximumTemperatureThreshold { get; private set; }
    public decimal MinimumHumidityThreshold { get; private set; }

    public Thing() { }

    public Thing(CreateThingCommand command)
    {
        Model = command.Model;
        MaximumTemperatureThreshold = command.MaximumTemperatureThreshold;
        MinimumHumidityThreshold = command.MinimumHumidityThreshold;
    }

    public void UpdateOperationMode(EOperationMode mode) => OperationMode = mode;

    public string SerialNumberValue => SerialNumber.Value.ToString();
}