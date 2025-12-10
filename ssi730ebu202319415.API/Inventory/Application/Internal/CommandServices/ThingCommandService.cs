using ssi730ebu202319415.API.Inventory.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Inventory.Domain.Model.Commands;
using ssi730ebu202319415.API.Inventory.Domain.Repositories;
using ssi730ebu202319415.API.Shared.Domain.Repositories;

namespace ssi730ebu202319415.API.Inventory.Application.Internal.CommandServices;

public class ThingCommandService(IThingRepository repository, IUnitOfWork unitOfWork) : IThingCommandService
{
    public async Task<Thing?> Handle(CreateThingCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Model))
            throw new Exception("Model cannot be empty");

        if (command.MaximumTemperatureThreshold < -40.00m || command.MaximumTemperatureThreshold > 85.00m)
            throw new Exception("MaximumTemperatureThreshold out of range");

        if (command.MinimumHumidityThreshold < 0.00m || command.MinimumHumidityThreshold > 100.00m)
            throw new Exception("MinimumHumidityThreshold out of range");

        var thing = new Thing(command);

        var exists = await repository.FindBySerialNumberAsync(thing.SerialNumber);
        if (exists != null)
            throw new Exception("SerialNumber already exists");

        await repository.AddAsync(thing);
        await unitOfWork.CompleteAsync();
        return thing;
    }
}