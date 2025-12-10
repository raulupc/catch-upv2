namespace ssi730ebu202319415.API.Inventory.Domain.Model.Commands;

public record CreateThingCommand(string Model, decimal MaximumTemperatureThreshold, decimal MinimumHumidityThreshold);