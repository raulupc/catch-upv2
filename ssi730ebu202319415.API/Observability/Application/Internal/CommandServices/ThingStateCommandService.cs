using ssi730ebu202319415.API.Observability.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Observability.Domain.Model.Commands;
using ssi730ebu202319415.API.Observability.Domain.Repositories;
using ssi730ebu202319415.API.Observability.Domain.Services;
using ssi730ebu202319415.API.Shared.Domain.Repositories;
using ssi730ebu202319415.API.Inventory.Domain.Model.Enumerations;
using ssi730ebu202319415.API.Observability.Domain.Model.ValueObjects;

namespace ssi730ebu202319415.API.Observability.Application.Internal.CommandServices;

public class ThingStateCommandService(
    IThingStateRepository repository,
    IInventoryAcl inventoryAcl,
    IUnitOfWork unitOfWork) : IThingStateCommandService
{
    public async Task<ThingState?> Handle(CreateThingStateCommand command)
    {
        if (command.CurrentOperationMode is < 0 or > 2)
            throw new Exception("CurrentOperationMode must be 0, 1 or 2");

        if (command.CollectedAt > DateTime.Now)
            throw new Exception("CollectedAt cannot be in the future");

        var exists = await repository.FindByThingSerialNumberAndCollectedAtAsync(
            new ThingSerialNumber(command.ThingSerialNumber), command.CollectedAt);

        if (exists != null)
            throw new Exception("ThingState already exists with same serial and date");

        var thingExists = await inventoryAcl.ExistsThingAsync(command.ThingSerialNumber);
        if (!thingExists)
            throw new Exception("Thing with this serialNumber does not exist");

        var state = new ThingState(command);
        await repository.AddAsync(state);
        await unitOfWork.CompleteAsync();

        await inventoryAcl.UpdateOperationModeAsync(command.ThingSerialNumber, (EOperationMode)command.CurrentOperationMode);

        return state;
    }
}