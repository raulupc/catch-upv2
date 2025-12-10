namespace ssi730ebu202319415.API.Inventory.Interfaces.REST.Resources;

public record ThingResource(int Id, string SerialNumber, string Model, string OperationMode, decimal MaximumTemperatureThreshold, decimal MinimumHumidityThreshold);