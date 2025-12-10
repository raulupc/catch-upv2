namespace ssi730ebu202319415.API.Inventory.Interfaces.REST.Resources;

public record CreateThingResource(string Model, decimal MaximumTemperatureThreshold, decimal MinimumHumidityThreshold);