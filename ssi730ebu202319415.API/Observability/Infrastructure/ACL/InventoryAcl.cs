using ssi730ebu202319415.API.Inventory.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Inventory.Domain.Model.Enumerations;
using ssi730ebu202319415.API.Inventory.Domain.Model.ValueObjects;
using ssi730ebu202319415.API.Inventory.Domain.Repositories;
using ssi730ebu202319415.API.Observability.Domain.Services;
using ssi730ebu202319415.API.Shared.Domain.Repositories;

namespace ssi730ebu202319415.API.Observability.Infrastructure.ACL;

public class InventoryAcl(IThingRepository thingRepository, IUnitOfWork unitOfWork) : IInventoryAcl
{
    public async Task<bool> ExistsThingAsync(Guid serialNumber)
    {
        var thing = await thingRepository.FindBySerialNumberAsync(new SerialNumber(serialNumber));
        return thing != null;
    }

    public async Task UpdateOperationModeAsync(Guid serialNumber, EOperationMode mode)
    {
        var thing = await thingRepository.FindBySerialNumberAsync(new SerialNumber(serialNumber));
        if (thing == null) throw new Exception("Thing not found");
        thing.UpdateOperationMode(mode);
        thingRepository.Update(thing);
        await unitOfWork.CompleteAsync();
    }
}